using D15immutablecirkelProject.Domein;

namespace D15immutablecirkelProject.CUI
{
    public class CirkelApp
    {
        public void Run()
        {
            Cirkel c1 = new Cirkel(3.45);

            Console.WriteLine(c1.Oppvervlakte());
            // fout bij aanpassen van straal , read only bvb : c1.Straal = 20.0;

        }
    }
}
