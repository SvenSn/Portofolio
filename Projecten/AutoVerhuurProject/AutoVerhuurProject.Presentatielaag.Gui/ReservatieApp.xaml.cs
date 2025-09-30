using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Domein.DTOs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AutoVerhuurProject.Presentatielaag.Gui;


public partial class ReservatieApp : Window
{
    private ReserveringManager _rm;
    private VestigingManager _vm;
    private AutoManager _am;

   
    private VestigingDTO geselecteerdeVestiging;
    private AutoDTO geselecteerdeAuto;
    private VestigingDTO geselecteerTerugbrengVestiging;

    private DateTime beginHuurPeriode;
    private DateTime eindeHuurPeriode;
    private DateTime zoekDate;

    private KlantenApp _klantapp;

    public ReservatieApp(ReserveringManager rm,VestigingManager vm,AutoManager am,KlantenApp klantApp)
    {
        
        InitializeComponent();
        _rm = rm;
        _vm = vm;
        _am = am;
        _klantapp = klantApp;

     
        VestigingLijstView.ItemsSource = _vm.GeefAlleVestigingen();
        TerugBrengVestigingLijst.ItemsSource = _vm.GeefAlleVestigingen();
        ReserveringenLijstView.ItemsSource = _rm.GeefAlleReserveringen();

        

        
        
        FilterByZitplaatsen.ItemsSource = new List<string> { "Zitplaatsen","Motortype"};
        ZoekFilters.ItemsSource = new List<string> { "Voornaam", "Achternaam", "Luchthaven", "Begindatum", "Einddatum", "Model Auto" };
        ReserveringenLijstView.Items.Filter = GetFilterReservaties();
       
        GeefAutosBijVestiging();

        DatumBegin.BlackoutDates.AddDatesInPast();
        RefreshDates();
        
    }


    private void RefreshDates()
    {
        EindeDatum.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, beginHuurPeriode));
        EindeDatum.BlackoutDates.AddDatesInPast();
    }



    public Predicate<object> GetFilterReservaties()
    {
        switch (ZoekFilters.SelectedItem as string)
        {
            case "Voornaam": return VoornaamFilterReservatie;
            case "Achternaam": return AchternaamFilterReservatie;
            case "Luchthaven": return LuchthavenFilterReservatie;
            case "Begindatum": return BegindatumFilterReservatie;
            case "Einddatum": return EinddatumFilterReservatie;
            case "Model Auto": return ModelAutoFilterReservatie;
        }
        return VoornaamFilterReservatie;
        
    }

    private bool ModelAutoFilterReservatie(object obj)
    {
        var automodelFilterReservatie = obj as ReserveringDTO;
        return automodelFilterReservatie.autoDTO.Model.Contains(txtZoekFilter.Text, StringComparison.OrdinalIgnoreCase);
    }

    private bool EinddatumFilterReservatie(object obj)
    {
        var einddatumFilterReservatie = obj as ReserveringDTO;
        return einddatumFilterReservatie.EindeHuurPeriode.Equals(zoekDate);
    }

    private bool BegindatumFilterReservatie(object obj)
    {
        var begindatumFilterReservatie = obj as ReserveringDTO;
        return begindatumFilterReservatie.EindeHuurPeriode.Equals(zoekDate);
    }

    private bool LuchthavenFilterReservatie(object obj)
    {
        var luchthavenFilterReservatie = obj as ReserveringDTO;
        return luchthavenFilterReservatie.vestigingDTO.LuchthavenVestiging.Contains(txtZoekFilter.Text,StringComparison.OrdinalIgnoreCase);
    }

    private bool AchternaamFilterReservatie(object obj)
    {
        var AchternaamFilterReservatie = obj as ReserveringDTO;
        return AchternaamFilterReservatie.klantDTO.Achternaam.Contains(txtZoekFilter.Text, StringComparison.OrdinalIgnoreCase);
    }

    public Predicate<object> GetFilterAutos()
    {
        switch (FilterByZitplaatsen.SelectedItem as string)
        {
            case "Zitplaatsen": return ZitplaatsenFilter;
            case "Motortype": return MotorTypeFilter;
        }
        return ZitplaatsenFilter;
    }

    private bool VoornaamFilterReservatie(object obj)
    {
        var voornaamFilterReservatie = obj as ReserveringDTO;
        return voornaamFilterReservatie.klantDTO.Voornaam.Contains(txtZoekFilter.Text, StringComparison.OrdinalIgnoreCase);
    }
    private bool MotorTypeFilter(object obj)
    {
        var motortypeFilter = obj as AutoDTO;

        return motortypeFilter.MotorType.Contains(txtZitplaatsen.Text, StringComparison.OrdinalIgnoreCase);
    }

    private bool ZitplaatsenFilter(object obj)
    {
        var zitplaatsfilter = obj as AutoDTO;
        int.TryParse(txtZitplaatsen.Text, out int getal);

        return zitplaatsfilter.Zitplaatsen >= getal;
    }

   

    private void GeefAutosBijVestiging()
    {
        if(geselecteerdeVestiging == null)
        {
            AutosLijstViewVestiging.ItemsSource = _am.GeefAlleAutos();
        }
        else
        {
            AutosLijstViewVestiging.ItemsSource = _am.GeefAutosBijVestiging(geselecteerdeVestiging.LuchthavenVestiging);
        }
    }



    private void AutosLijstViewVestiging_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (AutosLijstViewVestiging.SelectedItem == null)
        {
            MessageBox.Show("U heeft geen auto gekozen!");
        }
        else
        {
            geselecteerdeAuto = (AutoDTO)AutosLijstViewVestiging.SelectedItem;
        }
    }

    private void Datepicker_SelectionChanged_BeginDatum(object sender, SelectionChangedEventArgs e)
    {
        if (DatumBegin.SelectedDate.Value == null)
        {
            MessageBox.Show("Geef een startdatum in!.");
        }
        else
        {
            beginHuurPeriode = DatumBegin.SelectedDate.Value;
        }
        RefreshDates();

    }

    private void Datepicker_SelectionChanged_EindeDatum(object sender, SelectionChangedEventArgs e)
    {
        if(EindeDatum.SelectedDate.Value == null)
        {
            MessageBox.Show("Geef een einddatum in!.");
        }
        else
        {
            eindeHuurPeriode = EindeDatum.SelectedDate.Value;
        }
            
    }

    private void RefreshAutoListVestging()
    {
        AutosLijstViewVestiging.ItemsSource = _am.GeefAutosBijVestiging(geselecteerdeVestiging.LuchthavenVestiging);
    }

    private void VestigingLijstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (VestigingLijstView.SelectedItem is VestigingDTO vestiging)
        {
            geselecteerdeVestiging = vestiging;
            RefreshAutoListVestging();
        }
    }

    private void txtZitplaatsen_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if(txtZitplaatsen.Text == null)
        {
            AutosLijstViewVestiging.Items.Filter = null;
        }
        else
        {
            AutosLijstViewVestiging.Items.Filter = GetFilterAutos();
        }
    }


    private void FilterByZitplaatsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AutosLijstViewVestiging.Items.Filter = GetFilterAutos();
    }

    private void TerugBrengVestigingLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (TerugBrengVestigingLijst.SelectedItem is VestigingDTO vestiging)
        {
            geselecteerTerugbrengVestiging = vestiging;
        }
    }

    private void ButtonReservatie_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if(_rm.IsAutosBeschikBaar(geselecteerdeAuto.Nummerplaat,beginHuurPeriode,eindeHuurPeriode) == true)
            {
                _rm.VoegReserveringToe(_klantapp.GeefKlantTerug(), geselecteerdeVestiging, geselecteerdeAuto, beginHuurPeriode, eindeHuurPeriode);
                _am.UpdateVestigingVanAuto(geselecteerdeAuto, geselecteerTerugbrengVestiging.LuchthavenVestiging);
                VestigingLijstView.ItemsSource = _vm.GeefAlleVestigingen();
                MessageBox.Show($"De reservatie is gemaakt op naam van {_klantapp.GeefKlantTerug().Voornaam}" +
                    $" {_klantapp.GeefKlantTerug().Achternaam}");
                _rm.GeefAlleReserveringen();
            }
            else
            {
                MessageBox.Show("Deze auto is niet beschikbaar voor deze reservatie");
            }

        }
        catch
        {
            throw new ArgumentException("Er is iets fout gegaan");
        }

    }

    

    private void ZoekFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ReserveringenLijstView.Items.Filter = GetFilterReservaties();
    }

    private void txtZoekFilter_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (txtZoekFilter.Text == null)
        {
            ReserveringenLijstView.Items.Filter = null;
        }
        else
        {
            ReserveringenLijstView.Items.Filter = GetFilterReservaties();
        }
    }

    private void DateZoekFilter_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        zoekDate = DateZoekFilter.SelectedDate.Value.Date;
        MessageBox.Show("" + zoekDate);
    }
}