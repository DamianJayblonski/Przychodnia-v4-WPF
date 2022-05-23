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
    /// Logika interakcji dla klasy DodajEdytuj.xaml
    /// </summary>
    public partial class DodajEdytuj : Window
    {
 
        public int PacjentID { get; set; }
        public string BBImie { get; set; }
        public string BBNazwisko { get; set; }
        public string BBAdres { get; set; }
        public string BBPlec { get; set; }
        public string BBPesel { get; set; }

        public DodajEdytuj(int PacjentIDDJ)
        {

            this.PacjentID = PacjentIDDJ;
            if (PacjentID > 0)
            {
                Wypelnij();
            }
            DataContext = this;
            InitializeComponent();
        }

        private void Wypelnij()
        {
            using (var db = new PacjentContext())
            {
                var SelectedPacjent = db.Pacjents.Find(PacjentID);
                BBImie = SelectedPacjent.Imie;
                BBNazwisko = SelectedPacjent.Nazwisko;
                BBPesel = SelectedPacjent.Pesel;
                BBAdres = SelectedPacjent.Adres;
                BBPlec = SelectedPacjent.Plec;
            }
               
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PacjentContext())
            {
                if (PacjentID > 0)
                {

                    var SelectedPacjent = db.Pacjents.Find(PacjentID);
                    SelectedPacjent.Imie = BBImie;
                    SelectedPacjent.Nazwisko = BBNazwisko;
                    SelectedPacjent.Pesel = BBPesel;
                    SelectedPacjent.Adres = BBAdres;
                    SelectedPacjent.Plec = BBPlec;
                    db.SaveChanges();
                }
                else
                {
                    db.Add(new Pacjent()
                    {
                        Nazwisko = BBNazwisko,
                        Imie = BBImie,
                        Adres = BBAdres,
                        DataUrodzenia = new DateTime(1978, 1, 18, 0, 0, 0),
                        Plec = BBPlec,
                        Pesel = BBPesel
                    });
                    db.SaveChanges();
                }
            }

            Close();
        }
        private void closeButton_Click(object sender, RoutedEventArgs e) =>
    
            Close();

        }
}

