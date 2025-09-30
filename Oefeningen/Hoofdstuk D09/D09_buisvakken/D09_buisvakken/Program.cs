namespace D09_buisvakken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //De punten voor een vak staan steeds op de overeenkomstige positie in het punten array.
            //Bv. op index 1 vinden we dat de student voor het vak Engels een score van 55 behaalde (op 100).
            //Schrijf een programma dat toont voor welke vakken de student een onvoldoende behaalde.

            string[] vakken = { "Frans", "Engels", "Wiskunde", "Duits", "L.O." };
            int[] scores = { 34, 55, 20, 10, 80 };


            for (int i = 0; i < scores.Length; i++)
            {
                int score = scores[i];  

                if (score < 50)
                {
                    Console.WriteLine(vakken[i]);
                }
            }


        }
    }
}
