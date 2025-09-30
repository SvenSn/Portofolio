namespace D09herkansing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] puntenlijst = { 13, 16, 13, 18, 8, 12, 15, 3, 4, 11, 17, 18 };

            bool herkansingNodig = true;

            foreach (int i in puntenlijst)
            {
                if(i < 10)
                {
                    herkansingNodig = true;
                    break;
                }
                else
                {
                    herkansingNodig = false;
                }
            }

            if ( herkansingNodig )
            {
                Console.WriteLine("Er is een herkansing nodig.");
            }
            else
            {
                Console.WriteLine("Er is geen herkansing nodig.");
            }
        }
    }
}
