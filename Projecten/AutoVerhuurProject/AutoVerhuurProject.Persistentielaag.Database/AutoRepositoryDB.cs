using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerhuurProject.Persistentielaag.Database;

public class AutoRepositoryDB : IAutoRepositoryRead
{

    private readonly string _connectionstring;

    public AutoRepositoryDB(string connectionstring)
    {
        _connectionstring = connectionstring;
    }


    private static AutoDTO MapAutoFromReader(SqlDataReader reader)
    {

        string nummerplaat = reader.GetString(0);
        string model = reader.GetString(1);
        int zitplaatsen = reader.GetInt32(2);
        string motortype = reader.GetString(3);


        return new AutoDTO(nummerplaat, model, zitplaatsen,motortype);

    }

    public IEnumerable<AutoDTO> GetAll()
    {
        var autos = new List<AutoDTO>();

        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();


        const string query = @"select a.* from autos a ;";

        using SqlCommand command = new SqlCommand(query, connection);

        using SqlDataReader reader = command.ExecuteReader();


        while (reader.Read())
        {
            AutoDTO auto = MapAutoFromReader(reader);

            if (auto != null)
            {
                autos.Add(auto);
            }
        }
        return autos;
    }

    public AutoDTO GetByNummerplaat(string nummerplaat)
    {
        using SqlConnection connection = new SqlConnection(_connectionstring);
        connection.Open();

        const string query = @"select a.* from autos a where a.nummerplaat = @Nummerplaat ";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nummerplaat", nummerplaat);

        using var reader = command.ExecuteReader();
        try
        {
            if (reader.Read())
            {
                return MapAutoFromReader(reader);
            }
        }
        catch
        {
            throw new ArgumentException("Nummerplaat is niet in de database.");
        }

        return null;
    }

    public IEnumerable<AutoDTO> GetByVestiging(string luchthaven)
    {
        var autos = new List<AutoDTO>();

        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query = @"select a.* from autos a 
                              where a.vestiging_luchthaven = @Luchthaven;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Luchthaven", luchthaven);

        using var reader = command.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                AutoDTO auto = MapAutoFromReader(reader);

                if(auto != null)
                {
                    autos.Add(auto);
                }
            }

            return autos;
        }catch
        {
            throw new ArgumentException("Deze vestiging is niet gevonden.");
        }

    }

    public void Update(AutoDTO auto, string luchthaven)
    {
        using var connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query = "update Autos set vestiging_luchthaven =@Vestiging " +
            "where nummerplaat = @Nummerplaat;";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Vestiging", luchthaven);
        command.Parameters.AddWithValue("@Nummerplaat", auto.Nummerplaat);
    }
}
