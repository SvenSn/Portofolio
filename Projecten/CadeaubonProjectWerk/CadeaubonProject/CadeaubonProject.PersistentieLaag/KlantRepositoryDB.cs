using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;

namespace CadeaubonProject.PersistentieLaag.Databank;

public class KlantRepositoryDB : IKlantRepository
{

    private readonly string _connectionstring;

    public KlantRepositoryDB(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    public void Add(KlantDTO klant)
    {
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        const string query = "INSERT INTO Klanten (id,email,passwoord,voornaam,achternaam) VALUES" +
            "(@Id,@Email,@Passwoord,@Voornaam,@Achternaam)";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", klant.KlantId);
        command.Parameters.AddWithValue("@Email", klant.Email);
        command.Parameters.AddWithValue("@Passwoord", klant.Passwoord);
        command.Parameters.AddWithValue("@Voornaam", klant.Voornaam);
        command.Parameters.AddWithValue("@Achternaam", klant.Achternaam);

        command.ExecuteNonQuery();

    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<KlantDTO> GetAll()
    {
        var klanten = new List<KlantDTO>();

        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query = @"SELECT k.id,k.email,k.passwoord,k.voornaam,k.achternaam FROM klanten k;";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            KlantDTO klant = MapKlantFromReader(reader);

            if (klant != null)
            {
                klanten.Add(klant);
            }
        }

        return klanten;
    }

    public void Update(Guid id)
    {
        throw new NotImplementedException();
    }

    private static KlantDTO MapKlantFromReader(SqlDataReader reader)
    {
        Guid klantid = reader.GetGuid(0);
        string email = reader.GetString(1);
        string passwoord = reader.GetString(2);
        string voornaam = reader.GetString(3);
        string achternaam = reader.GetString(4);


        return new KlantDTO(klantid, email, passwoord, voornaam, achternaam);
    }


    public KlantDTO? GetByEmail(string email)
    {
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();


        const string query = @"SELECT k.id,k.email,k.passwoord,k.voornaam,k.achternaam from klanten k where k.email = @Email;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Email", email);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return MapKlantFromReader(reader);
        }
        else
        {
            return null;
        }
    }

    public KlantDTO? GetById(Guid id)
    {
        const string query = @"SELECT k.id,k.email,k.passwoord,k.voornaam,k.achternaam from klanten k where k.id = @Id;";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapKlantFromReader(reader);
        }
        else
        {
            return null;
        }
    }
}
