namespace D18reversedstringcomparer.Domein
{
    public class ReversedStringComparer : IComparer<string>
    {
        static private string ReverseText(String text)
        {
            string result = "";
            foreach (char c in text)
            {
                result = c + result;
            }
            return result;
        }

        public int Compare(string x, string y)
        {
            string reverseX = ReverseText(x);   
            string reverseY = ReverseText(y);
            return reverseX.CompareTo(reverseY);
        }


    }
}
