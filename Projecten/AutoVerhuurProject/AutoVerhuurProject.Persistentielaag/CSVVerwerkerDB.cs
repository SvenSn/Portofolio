using Microsoft.Data.SqlClient;

namespace AutoVerhuurProject.Persistentielaag;

public class CSVVerwerkerDB(string connectionString)
{
    


    public void LeegDatabase()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Zet constraints tijdelijk uit om afhankelijkheden te vermijden
            using (SqlCommand disableFK = new SqlCommand("ALTER TABLE Vestigingen NOCHECK CONSTRAINT ALL; ALTER TABLE Reserveringen NOCHECK CONSTRAINT ALL;", conn))
            {
                disableFK.ExecuteNonQuery();
            }

            // Verwijder gegevens uit de tabellen
            string[] tabelNamen = { "Reserveringen", "Vestigingen", "Autos", "Klanten" };

            foreach (string tabel in tabelNamen)
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {tabel};", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Zet constraints weer aan
            using (SqlCommand enableFK = new SqlCommand("ALTER TABLE Vestigingen CHECK CONSTRAINT ALL; ALTER TABLE Reserveringen CHECK CONSTRAINT ALL;", conn))
            {
                enableFK.ExecuteNonQuery();
            }

            Console.WriteLine("Database is succesvol geleegd.");
        }
    }


    public void VerwerkAutos(string bestandspad)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            foreach (var regel in File.ReadAllLines(bestandspad).Skip(1)) // Skip de header
            {
                var gegevens = regel.Split(';');
                if (gegevens.Length >= 4)
                {
                    string nummerplaat = gegevens[0];
                    string model = gegevens[1];
                    int zitplaatsen = int.Parse(gegevens[2]);
                    string motorType = gegevens[3];

                    string query = "INSERT INTO Autos (Nummerplaat, Model, Zitplaatsen, MotorType) VALUES (@Nummerplaat, @Model, @Zitplaatsen, @MotorType)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nummerplaat", nummerplaat);
                        cmd.Parameters.AddWithValue("@Model", model);
                        cmd.Parameters.AddWithValue("@Zitplaatsen", zitplaatsen);
                        cmd.Parameters.AddWithValue("@MotorType", motorType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public void VerwerkVestigingen(string bestandspad)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            foreach (var regel in File.ReadAllLines(bestandspad).Skip(1))
            {
                var gegevens = regel.Split(';');
                if (gegevens.Length >= 5)
                {
                    string luchthaven = gegevens[0];
                    string straat = gegevens[1];
                    string postcode = gegevens[2];
                    string plaats = gegevens[3];
                    string land = gegevens[4];

                    string query = "INSERT INTO Vestigingen (Luchthaven, Straat, Postcode, Plaats, Land) VALUES (@Luchthaven, @Straat, @Postcode, @Plaats, @Land)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Luchthaven", luchthaven);
                        cmd.Parameters.AddWithValue("@Straat", straat);
                        cmd.Parameters.AddWithValue("@Postcode", postcode);
                        cmd.Parameters.AddWithValue("@Plaats", plaats);
                        cmd.Parameters.AddWithValue("@Land", land);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public void VerwerkKlanten(string bestandspad)
    {
        HashSet<string> uniekeEmails = new HashSet<string>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            foreach (var regel in File.ReadAllLines(bestandspad).Skip(1))
            {
                var gegevens = regel.Split(';');
                if (gegevens.Length >= 7) // Zorgt ervoor dat alle velden aanwezig zijn
                {
                    string voornaam = gegevens[0];
                    string achternaam = gegevens[1];
                    string email = gegevens[2];
                    string straat = gegevens[3];
                    string postcode = gegevens[4];
                    string woonplaats = gegevens[5];
                    string land = gegevens[6];

                    // Controleer of e-mail al bestaat
                    if (uniekeEmails.Contains(email) || EmailBestaatAl(email, conn))
                    {
                        Console.WriteLine($"SKIPPED: Klant met e-mail {email} bestaat al.");
                        continue;
                    }

                    uniekeEmails.Add(email);

                    string query = @"INSERT INTO Klanten 
                                    (Voornaam, Achternaam, Email, Straat, Postcode, Woonplaats, Land) 
                                    VALUES 
                                    (@Voornaam, @Achternaam, @Email, @Straat, @Postcode, @Woonplaats, @Land)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Voornaam", voornaam);
                        cmd.Parameters.AddWithValue("@Achternaam", achternaam);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Straat", straat);
                        cmd.Parameters.AddWithValue("@Postcode", postcode);
                        cmd.Parameters.AddWithValue("@Woonplaats", woonplaats);
                        cmd.Parameters.AddWithValue("@Land", land);
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Toegevoegd: {voornaam} {achternaam} ({email})");
                }
                else
                {
                    Console.WriteLine($"ERROR: Klantgegevens onvolledig -> {regel}");
                }
            }
        }
    }


    public void KoppelAutosAanVestigingen()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Haal alle luchthavens (vestigingen) op
            List<string> vestigingen = new List<string>();
            using (SqlCommand cmd = new SqlCommand("SELECT luchthaven FROM Vestigingen", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    vestigingen.Add(reader.GetString(0));
                }
            }

            if (vestigingen.Count == 0)
            {
                Console.WriteLine("Geen vestigingen gevonden. Kan geen auto's toewijzen.");
                return;
            }

            // Haal alle auto's op
            List<string> autos = new List<string>();
            using (SqlCommand cmd = new SqlCommand("SELECT nummerplaat FROM Autos WHERE vestiging_luchthaven IS NULL", conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    autos.Add(reader.GetString(0));
                }
            }

            if (autos.Count == 0)
            {
                Console.WriteLine(" Alle auto's hebben al een vestiging.");
                return;
            }

            // Willekeurig auto's toewijzen aan vestigingen
            Random rnd = new Random();
            foreach (var auto in autos)
            {
                string randomVestiging = vestigingen[rnd.Next(vestigingen.Count)];

                using (SqlCommand cmd = new SqlCommand("UPDATE Autos SET vestiging_luchthaven = @Vestiging WHERE nummerplaat = @Nummerplaat", conn))
                {
                    cmd.Parameters.AddWithValue("@Vestiging", randomVestiging);
                    cmd.Parameters.AddWithValue("@Nummerplaat", auto);
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine($" {autos.Count} auto's willekeurig toegewezen aan vestigingen.");
        }
    }


    private bool EmailBestaatAl(string email, SqlConnection conn)
    {
        string query = "SELECT COUNT(1) FROM Klanten WHERE Email = @Email";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}



