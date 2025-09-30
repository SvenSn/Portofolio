using D15encrypterProject.Domein;

namespace D15encrypterProject.CUI
{
    public class EncrypterApp
    {
        public void Run()
        {
            Encrypter e5 = new Encrypter(5);
            string tekst = "a19z";
            string code = e5.GetCodeFor(tekst);
            Console.WriteLine("+ 5 " + tekst + "->" + code);

            tekst = "GROEN";
            Console.WriteLine("+ 5 " + tekst + "->" + e5.GetCodeFor(tekst));

            Encrypter e10 = new Encrypter(10);
            tekst = "c# !";
            Console.WriteLine("+10 " + tekst + "->" + e10.GetCodeFor(tekst));

            Console.WriteLine();

            tekst = "0allo?";
            Encrypter e1 = new Encrypter(1);
            Console.WriteLine("+ 1 " + tekst + "->" + e1.GetCodeFor(tekst));

            Encrypter e40 = new Encrypter(40);
            Console.WriteLine("+40 " + tekst + "->" + e40.GetCodeFor(tekst));

            Encrypter e41 = new Encrypter(41);
            Console.WriteLine("+41 " + tekst + "->" + e41.GetCodeFor(tekst));

            Encrypter em1 = new Encrypter(-1);
            Console.WriteLine("- 1 " + tekst + "->" + em1.GetCodeFor(tekst));

            Console.WriteLine();

            Encrypter em10 = new Encrypter(-10);
            Console.WriteLine("-10 " + tekst + "->" + em10.GetCodeFor(tekst));

            Encrypter em40 = new Encrypter(-40);
            Console.WriteLine("-40 " + tekst + "->" + em40.GetCodeFor(tekst));

            Encrypter em41 = new Encrypter(-41);
            Console.WriteLine("-41 " + tekst + "->" + em41.GetCodeFor(tekst));

            Encrypter em82 = new Encrypter(-82);
            Console.WriteLine("-82 " + tekst + "->" + em82.GetCodeFor(tekst));
        }
    }
}
