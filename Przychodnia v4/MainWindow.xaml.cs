using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Przychodnia_v2;

namespace Przychodnia_v4
{
    //Widok strony głównej
    public partial class MainWindow : Window
    {   //Deklaracja wszystkich list i zmiennych do sprawdzenia zaznaczonych danych w gridboxach
        public Pacjent SelectedPacjent { get; set; }
        public Rozpoznanie SelectedWizyta { get; set; }
        public Wypis SelectedHistoria { get; set; }
        public List<Pacjent> Pacjenci { get; set; } = Data.GetPacjents();
        public List<Rozpoznanie> Rozpoznania { get; set; } = Data.GetRozpoznianie();
        public List<Wypis> Wypisy { get; set; } = Data.GetWypis();
        public List<RodzajZabiegu> Zabiegi { get; set; } = Data.GetZabieg();
        public MainWindow()
        {
            InitializeComponent();
        }
        //Przyciski
        private void Dodaj_Button(object sender, RoutedEventArgs e)
        {
            DodajEdytuj win2 = new DodajEdytuj(0, this);
            win2.Show();

        }
        private void Dodaj_Wizyte_Button(object sender, RoutedEventArgs e)
        {
            if(SelectedPacjent != null)     
            { 
            DodajEdytujWizyty win2 = new DodajEdytujWizyty(0, SelectedPacjent.ID, this);
            win2.parentWindow = this;
            win2.Show();
            }
        }
        private void Dodaj_Historie_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedPacjent != null)
            {
                DodajEdytujHistorie win2 = new DodajEdytujHistorie(0, SelectedPacjent.ID, this);
                win2.parentWindow = this;
                win2.Show();
            }
        }
        private void Edytuj_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedPacjent != null)
            {
                DodajEdytuj win2 = new DodajEdytuj(SelectedPacjent.ID, this);
                win2.parentWindow = this;
                win2.Show();
            }

        }
        private void Edytuj_Wizyte_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedWizyta != null)
            {
                DodajEdytujWizyty win2 = new DodajEdytujWizyty(SelectedWizyta.ID, SelectedWizyta.PacjentID, this);
                win2.Show();
            }

        }
        private void Edytuj_Historie_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedHistoria != null)
            {
                DodajEdytujHistorie win2 = new DodajEdytujHistorie(SelectedHistoria.ID, SelectedHistoria.PacjentID, this);
                win2.Show();
            }

        }
        private void Usun_Button(object sender, RoutedEventArgs e)
        {

            UsunWindow win2 = new UsunWindow(SelectedPacjent.ID,0,0, this);
            win2.Show();
        }

        private void Usun_Wizyte_Button(object sender, RoutedEventArgs e)
        {

            UsunWindow win2 = new UsunWindow(0,SelectedWizyta.ID,0, this);
            win2.Show();
        }
        private void Usun_Historie_Button(object sender, RoutedEventArgs e)
        {

            UsunWindow win2 = new UsunWindow(0,0, SelectedHistoria.ID, this);
            win2.Show();
        }
        //funkcja przechwytująca zmianę pacjenta w gridzie pacjentów i wypisujaca w innych gridach wizyty i historie choroby pacjenta
        private void Pacjent_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                RozpoznanieDataGrid.ItemsSource = null;
                WypisDataGrid.ItemsSource = null;
            if (SelectedPacjent != null)
                {
                    Rozpoznania.Clear();
                    Wypisy.Clear();
                    using (var db = new PacjentContext())
                    {
                        foreach (var rozpoznanie in db.Rozpoznanies)
                        {
                            if (rozpoznanie.PacjentID == SelectedPacjent.ID)
                            {
                                foreach (var zabieg in db.RodzajZabiegus)
                                {
                                    if (zabieg.ID == rozpoznanie.RodzajZabieguID)
                                        rozpoznanie.RodzajZabiegu.Nazwa = zabieg.Nazwa;
                                }
                            Rozpoznania.Add(rozpoznanie);
                            }
                        }
                        foreach (var wypis in db.Wypiss)
                        {
                            if (wypis.PacjentID == SelectedPacjent.ID)
                            {
                                Wypisy.Add(wypis);
                            }
                        }
                }
                }
                RozpoznanieDataGrid.ItemsSource = Rozpoznania;
                WypisDataGrid.ItemsSource = Wypisy;
            
            }
     /// <summary>
     /// odświeża całą tablice
     /// </summary>
        public void Refresh()
            {
            

            categoryDataGrid.ItemsSource = null;
            Pacjenci = Data.GetPacjents();
            categoryDataGrid.ItemsSource = Pacjenci;

            WypisDataGrid.ItemsSource = null;
            Wypisy = Data.GetWypis();
            WypisDataGrid.ItemsSource = Wypisy;

            RozpoznanieDataGrid.ItemsSource = null;
            Rozpoznania = Data.GetRozpoznianie();
            RozpoznanieDataGrid.ItemsSource = Rozpoznania;
        }

       
    }
    } 
