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
    /// Logika interakcji dla klasy DodajEdytujWizyty.xaml
    /// </summary>
    public partial class DodajEdytujWizyty : Window
    {
        public int PacjentID { get; set; }
        public int WizytaID { get; set; }
        public string NazwaWizyty { get; set; }
        public int ZabieguID { get; set; }
        public DateTime DataZabiegu { get; set; }

        public MainWindow parentWindow;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PacjentContext())
            {
                if (WizytaID > 0)
                {

                    var SelectedWizyta = db.Rozpoznanies.Find(WizytaID);
                    SelectedWizyta.Nazwa = this.NazwaWizyty;
                    SelectedWizyta.RodzajZabieguID = 1;//this.ZabieguID;
                    SelectedWizyta.Data = this.DataZabiegu;
                    db.SaveChanges();


                }
                else
                {
                    db.Add(new Rozpoznanie()
                    {
                        PacjentID = this.PacjentID,
                        Nazwa = NazwaWizyty,
                        RodzajZabieguID = 1, //this.ZabieguID,
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

    }
}
