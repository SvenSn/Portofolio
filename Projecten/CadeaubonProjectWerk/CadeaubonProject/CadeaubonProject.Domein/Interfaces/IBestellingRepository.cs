using CadeaubonProject.Domein.DTOs;

namespace CadeaubonProject.Domein.Interfaces;

public interface IBestellingRepository
{
    void Add(BestellingDTO bestelling,string stripeID);
    void Delete(Guid id);
    IEnumerable<BestellingDTO> GetByKlantId(Guid klantID);
    List<BestellingDTO> GetAll();
    BestellingDTO GetById(Guid id);
    void AddTransaction(string stripeID,decimal prijsBetaald,string Beschrijving);
    void UpdateTransaction(string stripeId, string winkel, DateTime datum);
    string GetStripeId(Guid id);


}
