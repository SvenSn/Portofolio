namespace AutoVerhuurProject.Domein.Interfaces;

public interface ICSVGegevensRepositoryFull
{
    void LeegDatabase();

    void VerwerkAutos(string bestandspad);

    void VerwerkVestigingen(string bestandspad);

    void VerwerkKlanten(string bestandspad);

    void KoppelAutosAanVestigingen();

   
}
