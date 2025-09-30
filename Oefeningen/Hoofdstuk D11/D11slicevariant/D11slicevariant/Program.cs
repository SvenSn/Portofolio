namespace D11slicevariant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = { 34, 56, -89, 67, 100, -4, 34 };

            int[] kop = Slice(getallen, 0, 4);
            Console.WriteLine(String.Join("-", kop)); // toont 34, 56, -89, 67

            int[] staart = Slice(getallen, 3, 7);
            Console.WriteLine(String.Join("-", staart));  // toont 67, 100, -4, 34

            int[] midden = Slice(getallen, 2, 5);
            Console.WriteLine(String.Join("-", midden)); // toont -89, 67, 100

            int[] eentje = Slice(getallen, 2, 3);
            Console.WriteLine(String.Join("-", eentje));  // toont -89

            int[] leeg = Slice(getallen, 3, 3);
            Console.WriteLine(String.Join("-", leeg));  // toont niks
        }

        private static int[] Slice(int[] values, int startIndex, int eindIndex)
        {
            int[] sliceArray = new int[eindIndex-startIndex];

            for (int i = 0; i < sliceArray.Length; i++)
            {
                sliceArray[i] = values[startIndex+i];
            }

            return sliceArray;
        }
    }
}
