namespace D08woordslang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] woordslang = new string[5];


            bool isWoordSlang = false;

            for (int i = 0; i < woordslang.Length; i++)
            {
                Console.Write("Geef een woord: ");
                string invoer = Console.ReadLine();
                woordslang[i] = invoer;
            }



            for (int i = 0;i < woordslang.Length;i++)
            {
                char laatseLetter = woordslang[i][woordslang[i].Length-1];
                char eersteLetter = woordslang[i + 1][0];

                if (laatseLetter == eersteLetter)
                {
                    isWoordSlang = true;
                }
                else
                {
                    string nietWoordSlang = woordslang[i] +"-"+ woordslang[i+1];
                    Console.WriteLine($"Dit is geen woordslang:  {nietWoordSlang}");
                    isWoordSlang = false;
                    break;
                }
            }

            if ( isWoordSlang )
            {
                Console.WriteLine("de woordslang is: "+string.Join("-", woordslang));  
            }




        }
    }
}
