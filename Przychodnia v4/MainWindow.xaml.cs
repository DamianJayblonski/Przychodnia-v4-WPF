using System;
using System.Collections.Generic;
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
        public List<Pacjent> Pacjenci { get; set; } = Data.GetPacjents();
        public List<Rozpoznanie> Rozpoznania { get; set; } = Data.GetRozpoznianie();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Dodaj_Button(object sender, RoutedEventArgs e)
        {
            DodajEdytuj win2 = new DodajEdytuj(0);
            win2.Show();

        }
        private void Edytuj_Button(object sender, RoutedEventArgs e)
        {
            if (SelectedPacjent != null)
            {
                DodajEdytuj win2 = new DodajEdytuj(SelectedPacjent.ID);
                win2.Show();
            }

        }
        private void Usun_Button(object sender, RoutedEventArgs e)
        {
            categoryDataGrid.ItemsSource = null;
            Pacjenci = Data.GetPacjents();
            categoryDataGrid.ItemsSource = Pacjenci;
        }

        private void Pacjent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           RozpoznanieDataGrid.ItemsSource = null;
            if (SelectedPacjent != null)
            {
                Rozpoznania.Clear();
                using (var db = new PacjentContext())
                {
                    foreach (var rozpoznanie in db.Rozpoznanies)
                    {
                        if (rozpoznanie.PacjentID == SelectedPacjent.ID)
                        {
                            Rozpoznania.Add(rozpoznanie);
                        }
                    }
                }
            }
            RozpoznanieDataGrid.ItemsSource = Rozpoznania;
            // RozpoznanieDataGrid.Row.Clear();
        }
    }
}
