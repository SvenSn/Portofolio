namespace D11filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] meetwaarden = { 3, 6, 10, -1, -23, 0, -6, 7, 10, -15, -4, 10 };

            // Een variabele voor de return value van een Filter method oproep
            int[] gefilterd;

            // Filter alle meetwaarden die tussen -4 en 7 liggen (grenzen inclusief)
            gefilterd = Filter(meetwaarden, -4, 7);

            Console.WriteLine(String.Join(",", gefilterd));
            // De output is : 3,6,-1,0,7,-4
            // Let erop dat de volgorde van de waarden in de output gelijk is aan
            // hun onderlinge volgorde in het 'meetwaarden' array!

            // Filter alle meetwaarden die tussen 10 en 10 liggen (grenzen inclusief)
            // (anders gezegd, hou enkel de tienen over).
            gefilterd = Filter(meetwaarden, 10, 10);

            Console.WriteLine(String.Join(",", gefilterd));
            // De output is : 10,10,10
            // Let erop dat de waarde 10 drie keer voorkomt omdat ze ook
            // drie keer voorkwam in het 'meetwaarden' array.

            // Filter alle meetwaarden die tussen 100 en 200 liggen (grenzen inclusief)
            gefilterd = Filter(meetwaarden, 100, 200);

            Console.WriteLine(String.Join(",", gefilterd));
            // De output is :
            // Let erop dat de output een lege regel is, er zijn immers geen
            // waarden tussen 100 en 200 in 'meetwaarden'. De lengte van
            // array 'gefilterd' is nu dus gelijk aan 0!}
        }

        private static int[] Filter(int[] meetwaarden, int min, int max)
        {
            int teller = 0;

            int[] temp = new int[meetwaarden.Length];
            
            for (int i = 0; i < meetwaarden.Length; i++)
            {
                if (meetwaarden[i] >= min && meetwaarden[i] <= max)
                {
                    
                    temp[teller] = meetwaarden[i];
                    teller++;
                }
            }


            int[] gefilterd = new int[teller];
            Array.Copy(temp, gefilterd,teller);
            return gefilterd;

        }
    }
}
