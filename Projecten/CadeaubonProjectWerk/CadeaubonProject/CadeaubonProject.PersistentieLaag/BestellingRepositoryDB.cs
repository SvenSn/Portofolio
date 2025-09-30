using CadeaubonProject.Domein;
using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;
using System.Resources;

namespace CadeaubonProject.PersistentieLaag.Databank;

public class BestellingRepositoryDB : IBestellingRepository
{
    private readonly string _connectionstring;


    public BestellingRepositoryDB(string connectionString)
    {
        _connectionstring = connectionString;
    }


    public void Add(BestellingDTO bestelling,string stripeID)
    {
        string query = "INSERT INTO Bestellingen (id, beschrijving,cadeaubon_id, klant_id,ts_StripeID)" +
                        "VALUES (@AankoopId, @Beschrijving,@cadeaubonId, @KlantId,@StripeID)";
        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@AankoopId", bestelling.AankoopId);
        command.Parameters.AddWithValue("@beschrijving", bestelling.Beschrijving);
        command.Parameters.AddWithValue("@cadeaubonId", bestelling.cadeaubonDTO.Id);
        command.Parameters.AddWithValue("@klantId", bestelling.klantDTO.KlantId);
        command.Parameters.AddWithValue("@StripeID", stripeID);
    
        connection.Open();
        command.ExecuteNonQuery();
    }

    public void AddTransaction(string stripeID, decimal prijsBetaald, string beschrijving)
    {
        string query = "INSERT INTO Transacties (StripeID,PrijsBetaald,Beschrijving)" +
                            "VALUES(@StripeID,@PrijsBetaald,@Beschrijving)";
        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);


        command.Parameters.AddWithValue("@StripeID", stripeID);
        command.Parameters.AddWithValue("@PrijsBetaald", prijsBetaald);
        command.Parameters.AddWithValue("@Beschrijving", beschrijving);


        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        string query = "DELETE FROM Bestellingen WHERE AankoopId = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public List<BestellingDTO> GetAll()
    {
        throw new NotImplementedException();
    }// TO-DO?

    public  BestellingDTO? GetById(Guid id)
    {
        string query = @"SELECT b.id, b.beschrijving,
                            k.id, k.email, k.passwoord, k.voornaam, k.achternaam,
                            c.id, c.prijs, c.thema, c.geldigtot
                            FROM Bestelling b 
                            JOIN klanten k on b.klant_id = k.id
                            JOIN cadeaubonnen c on b.cadeaubon_id = c.id
                            WHERE b.id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            BestellingDTO bestelling = new BestellingDTO(
               reader.GetGuid(0),
               reader.GetString(1),
               new KlantDTO
               (
                  reader.GetGuid(2),
                  reader.GetString(3),
                  reader.GetString(4),
                  reader.GetString(5),
                  reader.GetString(6)
               ),
               new CadeaubonDTO
               (
                  reader.GetGuid(7),
                  reader.GetDecimal(8),
                  (ThemaType)reader.GetInt32(9),
                  reader.GetDateTime(10)
               ));


            return bestelling;
        }
        else
        {
            return null;
        }

    }

    public IEnumerable<BestellingDTO?> GetByKlantId(Guid id)
    {
        var bestellingen = new List<BestellingDTO>();   

        //(Guid KlantId, string Email, string Passwoord, string Voornaam, string Achternaam);
        string query = @"SELECT b.id, b.beschrijving,
                            k.id, k.email, k.passwoord, k.voornaam, k.achternaam,
                            c.id, c.prijs, c.thema, c.geldigtot
                            FROM Bestellingen b 
                            JOIN klanten k on b.klant_id = k.id
                            JOIN cadeaubonnen c on b.cadeaubon_id = c.id
                            WHERE b.klant_id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
                    BestellingDTO bestelling = new BestellingDTO(
                       reader.GetGuid(0),
                       reader.GetString(1),
                       new KlantDTO
                       (
                          reader.GetGuid(2),
                          reader.GetString(3),
                          reader.GetString(4),
                          reader.GetString(5),
                          reader.GetString(6)
                       ),
                       new CadeaubonDTO
                       (
                          reader.GetGuid(7),
                          reader.GetDecimal(8),
                          (ThemaType)reader.GetInt16(9),
                          reader.GetDateTime(10)
                       ));

                    bestellingen.Add(bestelling);
        }
            return bestellingen;

    }

    public void UpdateTransaction(string stripeId, string winkel, DateTime datum)
    {
        string query = @"UPDATE Transacties SET Winkelgebruikt = @winkel, DatumGebruikt = @datum WHERE StripeId = @stripeId";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@winkel", winkel);
        command.Parameters.AddWithValue("@datum", datum);
        command.Parameters.AddWithValue("@stripeId", stripeId);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public string GetStripeId(Guid id)
    {
        string stripeId;

        string query = @"SELECT b.ts_StripeID FROM Bestellingen b WHERE b.id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            stripeId = reader.GetString(0);
            return stripeId;
        }
        else
        {
            throw new Exception("Geen Stripe ID gevonden voor deze bestelling.");
        }

    }
}
