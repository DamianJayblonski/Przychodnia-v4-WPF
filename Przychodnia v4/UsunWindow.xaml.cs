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
   //delaracja zmiennych
    public partial class UsunWindow : Window
    {
        public MainWindow parentWindow;
        public int PacjentID { get; set; }
        public int WizytaID { get; set; }
        public int HistoriaID { get; set; }
        //przechwytywanie PacjentID oraz WizytaID
        public UsunWindow(int PacjentIDDJ,int WizytaIDDJ,int HistoriaIDDJ, MainWindow parent)
        {
            this.PacjentID = PacjentIDDJ;
            this.WizytaID = WizytaIDDJ;
            this.HistoriaID = HistoriaIDDJ;
            parentWindow = parent;
            InitializeComponent();
        }
        //funkcja usuwania wybranych rekordow
        private void Tak_Click(object sender, RoutedEventArgs e)
        {   using (var db = new PacjentContext()) 
            {
            var SelectedPacjent = db.Pacjents.Find(PacjentID);
                if (SelectedPacjent != null && SelectedPacjent.ID > 0)
                {
               
               
                    var Pacjent = db.Pacjents.Find(SelectedPacjent.ID);
                    db.Pacjents.Remove(Pacjent);
                    db.SaveChanges();


                }
            var SelectedWizyta = db.Rozpoznanies.Find(WizytaID);
                if (SelectedWizyta != null && SelectedWizyta.ID > 0)
                {


                    var Wizyta = db.Rozpoznanies.Find(SelectedWizyta.ID);
                    db.Rozpoznanies.Remove(Wizyta);
                    db.SaveChanges();


                }
            var SelectedHistoria = db.Wypiss.Find(HistoriaID);
                if (SelectedHistoria != null && SelectedHistoria.ID > 0)
                {


                    var Historia = db.Wypiss.Find(SelectedHistoria.ID);
                    db.Wypiss.Remove(Historia);
                    db.SaveChanges();


                }



                parentWindow.Refresh();
            }
            Close();
        }
        private void Nie_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
