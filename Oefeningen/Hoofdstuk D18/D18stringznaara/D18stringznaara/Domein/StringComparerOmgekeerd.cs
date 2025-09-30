namespace D18stringznaara.Domein
{
    public class StringComparerOmgekeerd : IComparer<string>
    {
        public int Compare(string a,string b ) 
        { 
            return -a.CompareTo(b);
        }

    }
}
