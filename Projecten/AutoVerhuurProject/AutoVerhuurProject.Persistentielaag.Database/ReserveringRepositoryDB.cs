using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace AutoVerhuurProject.Persistentielaag.Database;

public class ReserveringRepositoryDB :IReserveringRepositoryFull
{

    private readonly string _connectionstring;

    public ReserveringRepositoryDB(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    public IEnumerable<ReserveringDTO> GetAllReserveringen()
    {

        var reserveringen = new List<ReserveringDTO>();


        using SqlConnection connection = new SqlConnection(_connectionstring);

        connection.Open();

        const string query =
           @"
               SELECT r.id, 
                       k.voornaam, k.achternaam,k.email,k.straat,k.postcode,k.woonplaats,k.land
                       ,v.luchthaven,v.straat,v.postcode,v.plaats,v.land,
                       a.nummerplaat,a.model,a.zitplaatsen,a.motortype,
                       r.StartHuurPeriode, r.EindeHuurPeriode
                FROM Reserveringen r
                JOIN Klanten k ON r.klant_email = k.email
                JOIN Vestigingen v ON r.vestiging_luchthaven = v.luchthaven
                JOIN Autos a ON r.auto_nummerplaat = a.nummerplaat;";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            ReserveringDTO reservering = MapReserveringFromReader(reader);

            if (reservering != null)
            {
                reserveringen.Add(reservering);
            }
        }

        return reserveringen;

    }
    private static ReserveringDTO MapReserveringFromReader(SqlDataReader reader)
    {

        return new ReserveringDTO
            (
                reader.GetGuid(reader.GetOrdinal("id")),
                new KlantDTO
                (
                    reader.GetString(reader.GetOrdinal("voornaam")),
                reader.GetString(reader.GetOrdinal("achternaam")),
                reader.GetString(reader.GetOrdinal("email")),
                reader.GetString(reader.GetOrdinal("straat")),
                reader.GetString(reader.GetOrdinal("postcode")),
                reader.GetString(reader.GetOrdinal("woonplaats")),
                reader.GetString(reader.GetOrdinal("land"))
                ),
                new VestigingDTO
                (
                    reader.GetString(reader.GetOrdinal("luchthaven")),
                    reader.GetString(reader.GetOrdinal("straat")),
                    reader.GetString(reader.GetOrdinal("postcode")),
                    reader.GetString(reader.GetOrdinal("plaats")),
                    reader.GetString(reader.GetOrdinal("land"))
                ),
                new AutoDTO
                (
                    reader.GetString(reader.GetOrdinal("nummerplaat")),
                    reader.GetString(reader.GetOrdinal("model")),
                    reader.GetInt32(reader.GetOrdinal("zitplaatsen")),
                    reader.GetString(reader.GetOrdinal("motortype"))

                    ),
                       reader.GetDateTime(reader.GetOrdinal("starthuurperiode")),
                       reader.GetDateTime(reader.GetOrdinal("eindehuurperiode"))

            );
    }

    public bool IsAutoBeschikbaar(string nummerplaat,DateTime startdatum,DateTime einddatum)
    {
        using var connection = new SqlConnection(_connectionstring);
        connection.Open();

        const string query = "SELECT COUNT(*) from reserveringen where auto_nummerplaat = @Nummerplaat" +
            " and((@StartDatum >= starthuurperiode AND @StartDatum < eindehuurperiode) OR" +
            " (@EindDatum > starthuurperiode AND @EindDatum <= eindehuurperiode) OR" +
            " (@StartDatum <= starthuurperiode AND @EindDatum >= eindehuurperiode));";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nummerplaat", nummerplaat);
        command.Parameters.AddWithValue("@StartDatum", startdatum);
        command.Parameters.AddWithValue("@EindDatum", einddatum);

        int count = (int)command.ExecuteScalar();
        return count == 0;


    }



    public void Add(ReserveringDTO reservering)
    {
        using var connection = new SqlConnection(_connectionstring);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // Voeg product toe aan Product-tabel
            const string query = @"
                INSERT INTO reserveringen (starthuurperiode, eindehuurperiode,klant_email,vestiging_luchthaven,auto_nummerplaat)
                VALUES (@Starthuurperiode, @Eindehuurperiode, @Klant_email,@Vestiging_luchthaven,@Auto_nummerplaat)";

            using var reserveringCommand = new SqlCommand(query, connection, transaction);
            reserveringCommand.Parameters.AddWithValue("@Starthuurperiode", reservering.StartHuurPeriode);
            reserveringCommand.Parameters.AddWithValue("@Eindehuurperiode", reservering.EindeHuurPeriode);
            reserveringCommand.Parameters.AddWithValue("@Klant_email", reservering.klantDTO.Email);
            reserveringCommand.Parameters.AddWithValue("@Vestiging_luchthaven", reservering.vestigingDTO.LuchthavenVestiging);
            reserveringCommand.Parameters.AddWithValue("@Auto_nummerplaat", reservering.autoDTO.Nummerplaat);
            reserveringCommand.ExecuteNonQuery();



            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
