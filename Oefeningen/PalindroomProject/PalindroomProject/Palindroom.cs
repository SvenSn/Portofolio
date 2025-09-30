using System.Text;

namespace PalindroomProject;

internal class Palindroom
{
    private string _Tekst;

    public string Tekst
    {
        get { return _Tekst; }
        set 
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ongeldige tekst.");
            }
            else if (value.Length < 2)
            {
                throw new ArgumentException("De tekst moet meer dan 1 karakter bevatten");
            }
           
            else
            {
                _Tekst = value;
            }
                
                
        }
    }

    public Palindroom(string tekst)
    {
        Tekst = tekst;
    }

    public static bool isPalindroom(string tekst)
    {
        StringBuilder sr = new StringBuilder();

        for (int i = tekst.Length -1; i>=0; i--)
        {
            sr.Append(tekst[i]);
        }

        string omgekeerd = sr.ToString();

        return String.Equals(tekst, omgekeerd, StringComparison.OrdinalIgnoreCase);
    }

}
