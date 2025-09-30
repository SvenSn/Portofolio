using CadeaubonProject.Domein.DTOs;
using System.Windows.Controls;

namespace CadeaubonProject.Presentatielaag.Gui.Pages
{
    /// <summary>
    /// Interaction logic for AccountPagina.xaml
    /// </summary>
    public partial class AccountPagina : Page
    {
        private KlantDTO _klant;
        public AccountPagina(KlantDTO klant)
        {
            InitializeComponent();
            DataContext = klant;
        }




    }
}
