using SpelmetwapenProject.Domein;

namespace SpelmetwapenProject.CUI
{
    public class VoorwerpApp
    {
        public void Run()
        {
            Wapen[] wapens = new Wapen[2];
            Random rnd = new Random();
            wapens[0] = new Wapen(6,true,"colt",1.5,3);
            wapens[1] = new Wapen(23,false,"brown",0.5,1);

            Sleutel[] sleutels = new Sleutel[2];
            sleutels[0] = new Sleutel("voordeur",0.5,3,1);
            

            foreach (Wapen wapen in wapens)
            {
                Console.WriteLine(wapen.ToString());
            }
            Console.WriteLine(sleutels[0].ToString());
            Console.WriteLine($"Er zijn {Sleutel.AantalInOmloop()} sleutel(s) in omloop.");
            sleutels[1] = new Sleutel("achterdeur", 0.5, 1, 2);
            Console.WriteLine(sleutels[1].ToString());
            
            Console.WriteLine($"Er zijn {Sleutel.AantalInOmloop()} sleutel(s) in omloop.");
        }
    }
}
