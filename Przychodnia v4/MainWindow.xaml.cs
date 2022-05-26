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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pacjent SelectedPacjent { get; set; }
        public Rozpoznanie SelectedWizyta { get; set; }
        public List<Pacjent> Pacjenci { get; set; } = Data.GetPacjents();
        public List<Wizyta> Rozpoznania { get; set; } = Data.GetRozpoznianie(0);
        public List<Wypis> Wypisy { get; set; } = Data.GetWypis();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Dodaj_Button(object sender, RoutedEventArgs e)
        {
            DodajEdytuj win2 = new DodajEdytuj(0, this);
            win2.Show();

        }
        private void Edytuj_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedPacjent != null)
            {
                DodajEdytuj win2 = new DodajEdytuj(SelectedPacjent.ID, this);
                //  win2.parentWindow = this;
                win2.Show();
            }

        }
        private void Usun_Button(object sender, RoutedEventArgs e)
        {

            UsunWindow win2 = new UsunWindow(SelectedPacjent.ID, this);
            win2.Show();
           
        }

        private void Dodaj_Wizyte_Button(object sender, RoutedEventArgs e)
        {
            DodajEdytujWizyty win2 = new DodajEdytujWizyty(0,SelectedPacjent.ID, this);
            win2.Show();

        }
        private void Edytuj_Wizyte_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedPacjent != null)
            {
                DodajEdytujWizyty win2 = new DodajEdytujWizyty(SelectedWizyta.ID, SelectedPacjent.ID, this);
                //  win2.parentWindow = this;
                win2.Show();
            }

        }


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

                    RozpoznanieDataGrid.ItemsSource = null;
                    Rozpoznania = Data.GetRozpoznianie(SelectedPacjent.ID);
                    RozpoznanieDataGrid.ItemsSource = Rozpoznania;

                    /*foreach (var rozpoznanie in db.Rozpoznanies)
                        {
                            if (rozpoznanie.PacjentID == SelectedPacjent.ID)
                            {
                                //Rozpoznania.Add(rozpoznanie);
                            }
                        }
                    */
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
            public void Refresh()
            {   
                RozpoznanieDataGrid.ItemsSource = null;
                Rozpoznania = Data.GetRozpoznianie(SelectedPacjent.ID);
                RozpoznanieDataGrid.ItemsSource = Rozpoznania;

                categoryDataGrid.ItemsSource = null;
                Pacjenci = Data.GetPacjents();
                categoryDataGrid.ItemsSource = Pacjenci;
                
                
                
                WypisDataGrid.ItemsSource = null;
                Wypisy = Data.GetWypis();
                WypisDataGrid.ItemsSource = Wypisy;

        }

        private void RozpoznanieDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    } 
