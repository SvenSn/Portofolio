using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;

namespace AutoVerhuurProject.Persistentielaag.Database;

public class VestigingRepositoryDB : IVestigingRepositoryRead
{

    private readonly string _connectionstring;

    public VestigingRepositoryDB(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    public List<VestigingDTO> GetAll()
    {
        var vestigingen = new List<VestigingDTO>();

        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query =
            @"SELECT v.* from vestigingen v;";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            VestigingDTO vestiging = MapVestigingFromReader(reader);

            if (vestiging != null)
            {
                vestigingen.Add(vestiging);
            }
        }

        return vestigingen;
    }

    public VestigingDTO? GetByAuto()
    {
        throw new NotImplementedException();
    }

    public VestigingDTO? GetByName()
    {
        throw new NotImplementedException();
    }

    private static VestigingDTO MapVestigingFromReader(SqlDataReader reader)
    {
        //string LuchthavenVestiging,string StraatVestiging,
        //string PostcodeVestiging,string PlaatsVestiging,string LandVestiging

        string luchthaven = reader.GetString(0);
        string straat = reader.GetString(1);
        string postcode = reader.GetString(2);
        string plaats = reader.GetString(3);
        string land = reader.GetString(4);

        return new VestigingDTO(luchthaven,straat,postcode,plaats,land);
    }
}
