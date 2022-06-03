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
using System.Windows.Shapes;
using Przychodnia_v2;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Przychodnia_v4
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DodajEdytujWizyty : Window
    {
        public int PacjentID { get; set; }
        public int WizytaID { get; set; }
        public string NazwaWizyty { get; set; }
        public int ZabieguID { get; set; }
        public DateTime DataZabiegu { get; set; }

        public MainWindow parentWindow;
        //funkcja przelapujaca ID wizyty i ID pacjenta i wypelniajaca tabele w przypadku edycji
        public DodajEdytujWizyty(int WizytaIDDJ, int PacjentIDDJ, MainWindow parent)
        {
            WizytaID = WizytaIDDJ;
            PacjentID = PacjentIDDJ;
            if (WizytaID > 0)
            {
                Wypelnij();
            }
            DataContext = this;
            parentWindow = parent;
            InitializeComponent();
           
        }
        //funkcja wypelniajaca
        private void Wypelnij()
        {
            using (var db = new PacjentContext())
            {
                var SelectedWizyta = db.Rozpoznanies.Find(WizytaID);
                NazwaWizyty = SelectedWizyta.Nazwa;
                ZabieguID = SelectedWizyta.RodzajZabieguID;
                DataZabiegu = SelectedWizyta.Data;
                PacjentID = SelectedWizyta.PacjentID;
            }

        }
        //akceptacja wpisanych danych guzikiem akceptuj
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PacjentContext())
            {
                if (WizytaID > 0)
                {

                    var SelectedWizyta = db.Rozpoznanies.Find(WizytaID);
                    SelectedWizyta.Nazwa = this.NazwaWizyty;
                    SelectedWizyta.RodzajZabieguID = this.ZabieguID;
                    SelectedWizyta.Data = this.DataZabiegu;
                    db.SaveChanges();


                }
                else
                {
                    db.Add(new Rozpoznanie()
                    {
                        PacjentID = this.PacjentID,
                        Nazwa = NazwaWizyty,
                        RodzajZabieguID = this.ZabieguID,
                        Data = DataZabiegu
                       
                        
                    });
                    db.SaveChanges();
                }
            }
            parentWindow.Refresh();
            Close();
        }
        private void closeButton_Click(object sender, RoutedEventArgs e) =>

            Close();
        //wczytanie opcji do comboboxa
        public void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            using (var db = new PacjentContext())
            {
                foreach (var zabieg in db.RodzajZabiegus)
                {
                    list.Add(zabieg.Nazwa);
                }
            }
            var combo = sender as ComboBox;
            combo.ItemsSource = list;
            combo.SelectedIndex = (this.ZabieguID - 1);
        }
        //wykrycie wybranej opcji comboboxa i przekazanie jej do fukcji tworzenia rekordu
        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var selectedcomboitem = sender as ComboBox;
            string name = selectedcomboitem.SelectedItem as string;
            using (var db = new PacjentContext())
            {
                foreach (var zabieg in db.RodzajZabiegus)
                {
                    if (name == zabieg.Nazwa)
                        ZabieguID = zabieg.ID;
                        
                }
            }
            



        }
    }
}
