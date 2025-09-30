
namespace D14RechthoekProject.Domein
{
    public class Rechthoek
    {

        private double _hoogte;

        public double GetHoogte()
        {
            return _hoogte;
        }
        public void SetHoogte(double hoogte)
        {
            _hoogte = hoogte;   
        }

        private double _breedte;

        public double GetBreedte()
        {
            return _breedte ;
        }
        public void SetBreedte(double breedte)
        {
            _breedte = breedte; 
        }
        public double Oppervlakte()
        {
            return GetHoogte()*GetBreedte();
        }

    }
}
