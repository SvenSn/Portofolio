namespace D08_woordslang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma waarbij de gebruiker 5 woorden moet ingeven en het programma controleert of deze een woordslang vormen.


            string[] woorden = new string[5];

            
            bool isWoordenSlang = false;

            string invalid = "";

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Geef een woord in. ");
                woorden[i] = Console.ReadLine();
            }


            for (int i = 0;i < woorden.Length-1;i++)
            {
                char laatsteLetter = woorden[i][woorden[i].Length-1];

                char eersteLetter = woorden[i + 1][0];

                if (laatsteLetter == eersteLetter)
                {

                   isWoordenSlang = true;
                }
                else if (laatsteLetter != eersteLetter)
                {
                    isWoordenSlang = false ;
                    invalid = woorden[i] +"-"+ woorden[i+1];
                    Console.WriteLine($"Het is geen woordslang: {invalid}");
                    break;

                }
            }

            if (isWoordenSlang)
            {
                Console.WriteLine("De woordslang is: "+ string.Join("-",woorden));
            }
        
            
        }
    }
}
