namespace AutoVerhuurProject.Domein.Models;

internal class Vestiging
{
    public string LuchthavenVestiging { get; private set; }

    public string StraatVestiging { get; private set; } 

    public string PostcodeVestiging { get; private set; } 

    public string PlaatsVestiging { get; private set; } 

    public string LandVestiging { get; private set; }

    private List<Auto> _autos;

    public Vestiging(string luchthavenVestiging, string straatVestiging, string postcodeVestiging, string plaatsVestiging, string landVestiging)
    {
        LuchthavenVestiging =
        !String.IsNullOrEmpty(luchthavenVestiging) && !luchthavenVestiging.Contains("\t") && !luchthavenVestiging.Contains("\n")
        ? luchthavenVestiging : throw new ArgumentNullException("De luchthaven van de vestiging moet ingevuld zijn.");
        StraatVestiging =
         !String.IsNullOrEmpty(straatVestiging) && !straatVestiging.Contains("\t") && !straatVestiging.Contains("\n")
        ? straatVestiging : throw new ArgumentNullException("De straat van de vestiging moet ingevuld zijn.");
        PostcodeVestiging =
        !String.IsNullOrEmpty(postcodeVestiging) && !postcodeVestiging.Contains("\t") && !postcodeVestiging.Contains("\n")
        ? postcodeVestiging : throw new ArgumentNullException("De postcode van de vestiging moet ingevuld zijn.");
        PlaatsVestiging =
        !String.IsNullOrEmpty(plaatsVestiging) && !plaatsVestiging.Contains("\t") && !plaatsVestiging.Contains("\n")
        ? plaatsVestiging : throw new ArgumentNullException("De plaats van de vestiging moet ingevuld zijn.");
        LandVestiging =
        !String.IsNullOrEmpty(landVestiging) && !landVestiging.Contains("\t") && !landVestiging.Contains("\n")
        ? landVestiging : throw new ArgumentNullException("Het land van de vestiging moet ingevuld zijn.");

        _autos = new();
    }

   


    public void VoegAutosToe(Auto auto)
    {
        if (_autos.Contains(auto))
        {
            throw new ArgumentException("Deze auto staat al in de vestiging");
        }
        else
        {
            _autos.Add(auto);
        }
    }

    public List<Auto> GeefAutos()
    {
        return _autos;
    }


}
