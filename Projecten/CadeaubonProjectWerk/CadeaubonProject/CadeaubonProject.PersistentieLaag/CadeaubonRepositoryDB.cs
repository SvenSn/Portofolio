using CadeaubonProject.Domein;
using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;

namespace CadeaubonProject.PersistentieLaag.Databank;

public class CadeaubonRepositoryDB : ICadeaubonRepository
{
    private readonly string _connectionstring;

    public CadeaubonRepositoryDB(string connectionString)
    {
        _connectionstring = connectionString;
    }

    public void Add(CadeaubonDTO cadeaubon)
    {
        string query = "INSERT INTO Cadeaubonnen (id, prijs,thema, geldigtot)" +
                        "VALUES (@Id, @Prijs, @Thematype, @Datum)";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", cadeaubon.Id);
        command.Parameters.AddWithValue("@Prijs", cadeaubon.Saldo);
        command.Parameters.AddWithValue("@Thematype", ((int)cadeaubon.Thematype));
        command.Parameters.AddWithValue("@Datum", cadeaubon.Datum);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Delete(Guid id)
    {
        string query = "DELETE FROM Cadeaubonnen WHERE id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public IEnumerable<CadeaubonDTO> GetAll()
    {
        var cadeaubonnen = new List<CadeaubonDTO>();

        string query = "SELECT * FROM Cadeaubonnen";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var cadeaubon = new CadeaubonDTO(
                reader.GetGuid(0),
                reader.GetDecimal(1),
                (ThemaType)reader.GetInt32(2),
                reader.GetDateTime(3)
            );
            cadeaubonnen.Add(cadeaubon);
        }
        return cadeaubonnen;
    }



    public CadeaubonDTO GetById(Guid id)
    {
        string query = "SELECT * FROM Cadeaubonnen WHERE id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new CadeaubonDTO(
                reader.GetGuid(0),
                reader.GetDecimal(1),
                (ThemaType)reader.GetInt32(2),
                reader.GetDateTime(3)
            );
        } else
        {
            throw new ArgumentException("Geen cadeaubon met dit id gevonden");
        }
    }

    public void Update(Guid id, decimal bedrag)
    {
        string query = @"UPDATE Cadeaubonnen SET prijs = prijs - @bedrag WHERE id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@bedrag", bedrag);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void AddCadeaubonGebruik(Guid id, string winkel, DateTime datum, decimal waarde)
    {
        string query = @"INSERT INTO CadeaubonGebruik (cadeaubon_id, WinkelNaam, Datum, Waarde) " +
                       "VALUES (@cadeaubon_id, @WinkelNaam, @Datum, @Waarde)";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@cadeaubon_id", id);
        command.Parameters.AddWithValue("@WinkelNaam", winkel);
        command.Parameters.AddWithValue("@Datum", datum);
        command.Parameters.AddWithValue("@Waarde", waarde);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public IEnumerable<CadeaubonGebruikDTO> GetCadeaubonGebruik(Guid id)
    {
        var cadeaubonGebruiken = new List<CadeaubonGebruikDTO>();

        string query = @"SELECT WinkelNaam, Datum, Waarde FROM CadeaubonGebruik WHERE cadeaubon_id = @id";

        using SqlConnection connection = new SqlConnection(_connectionstring);
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@id", id);
        connection.Open();

        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var cadeaubonGebruik = new CadeaubonGebruikDTO(
                reader.GetString(0),
                reader.GetDateTime(1),
                reader.GetDecimal(2)
            );

            cadeaubonGebruiken.Add(cadeaubonGebruik);
        }

        return cadeaubonGebruiken;
    }
}

