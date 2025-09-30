using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PerfectGetalProject.Domein;

public class PerfectGetal
{
    public bool IsPerfect(int getal)
    {
        if  (getal < 1)
        {
            throw new ArgumentException("Getal moet positief zijn");
        }
        int som = 0;

        for (int i = 1; i <= getal / 2; i++) 
        {
            if (getal % i == 0) som += i; 

        }

        return som == getal;
    }

}
