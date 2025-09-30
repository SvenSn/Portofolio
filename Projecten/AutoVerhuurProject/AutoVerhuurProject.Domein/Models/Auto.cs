using static AutoVerhuurProject.Domein.Models.Auto;

namespace AutoVerhuurProject.Domein.Models;

internal class Auto(string nummerplaat, string model, int zitplaatsen, EMotorType motorType)
{
    public string Nummerplaat { get; } =
        String.IsNullOrEmpty(nummerplaat) || nummerplaat.Contains("\t") || nummerplaat.Contains("\n") ?
        throw new ArgumentNullException("De nummer plaat moet ingevuld zijn") : nummerplaat;


    public string Model { get; } =
        String.IsNullOrEmpty(model) || model.Contains("\t") || model.Contains("\n") ?
        throw new ArgumentNullException("Het model plaat moet ingevuld zijn") : model;


    public int Zitplaatsen { get; } =
        zitplaatsen >= 2 && zitplaatsen < 10 ? zitplaatsen : throw new ArgumentOutOfRangeException(nameof(Zitplaatsen), "Mimimum 2 zitplaatsen in de auto.");


    public EMotorType MotorType { get; } =
        Enum.IsDefined(typeof(EMotorType), motorType) ? motorType : throw new ArgumentException("Motortype moet ofwel elektrisch,diesel,benzine of hybride zijn.");

    public enum EMotorType // mag in de class zitten omdat het altijd aan de auto zal zitten...
    {
        Benzine,
        Elektrisch,
        Hybride,
        Diesel
    }
}
