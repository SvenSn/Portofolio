using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace AutoVerhuurProject.Persistentielaag.Database;

public class KlantRepositoryDB : IKlantRepositoryRead
{
    private readonly string _connectionstring;

    public KlantRepositoryDB(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    public IEnumerable<KlantDTO> GetAll()
    {
        var klanten = new List<KlantDTO>();

        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query =
            @"SELECT k.* from klanten k;";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            KlantDTO klant = MapKlantFromReader(reader);

            if(klant != null)
            {
                klanten.Add(klant);
            }
        }

        return klanten;
    }


    public KlantDTO? GetByEmail(string email)
    {
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        const string query = @"select k.* from klanten k where k.email = @Email;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Email", email);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return MapKlantFromReader(reader);
        }
        return null;
    }    

    private static KlantDTO MapKlantFromReader(SqlDataReader reader)
    {
        
        string voornaam = reader.GetString(0);
        string achternaam = reader.GetString(1);
        string email = reader.GetString(2);
        string straat = reader.GetString(3);
        string postcode = reader.GetString(4);
        string woonplaats = reader.GetString(5);
        string land = reader.GetString(6);

        return new KlantDTO(voornaam,achternaam,email,straat,postcode,woonplaats,land);
    }

    public IEnumerable<KlantDTO> GetByName(string naam)
    {
        var klanten = new List<KlantDTO>();

        using var connection = new SqlConnection(_connectionstring);
        connection.Open();

        const string query = "select k.* from klanten k where k.voornaam = @Naam OR k.achternaam = @Naam;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Naam",naam);

        using var reader = command.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                KlantDTO klant = MapKlantFromReader(reader);
                if (klant!= null)
                {
                    klanten.Add(klant);
                }
                else
                {
                    throw new ArgumentNullException("Geen klant gevonden.");
                }

            }
            return klanten;
           
        }
        catch
        {
            throw new ArgumentException("Er is iets mis gegaan in het opzoeken");
        }
    }
}
