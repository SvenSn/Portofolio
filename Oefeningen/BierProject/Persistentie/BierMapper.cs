using Domein;
using System.Collections.Generic;

namespace Persistentie
{
	public class BierMapper
	{
		public List<Bier> GeefBieren()
		{
            List<Bier> bierLijst = new List<Bier>();
            
            bierLijst.Add(new Bier("WestVleteren_Blond", "blond", 5.0, 9.3, "Sint-Sixtusabdij van Westvleteren"));
            bierLijst.Add(new Bier("Tripel_Kanunnik", "tripel", 8.2, 9.1, "Wilderen"));
            bierLijst.Add(new Bier("Black_Albert", "tripel", 13.0, 9.0, "De Struise Brouwers"));
            bierLijst.Add(new Bier("Rochefort_10", "donker", 11.0, 9.1, "Brasserie de l'Abbaye de Saint-Rémy"));
            bierLijst.Add(new Bier("Alpaïde", "donker", 9.5, 9.0, "Nieuwhuys Hoegaarden"));
            bierLijst.Add(new Bier("Cantillon_Geuze", "geuze", 5.0, 8.5, "Cantillon"));
            bierLijst.Add(new Bier("Moinette_Blonde", "blond", 8.5, 8.5, "Dupont"));
            bierLijst.Add(new Bier("Wilderen_Goud", "blond", 6.0, 8.4, "Wilderen"));
            bierLijst.Add(new Bier("Tripel_Karmeliet", "tripel", 8.4, 8.3, "Bosteels"));
            bierLijst.Add(new Bier("Westmalle_Tripel", "tripel", 9.5, 8.2, "Abdij der trappisten van Westmalle"));

            return bierLijst;
        }
	}
}