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
    /// Logika interakcji dla klasy UsunWindow.xaml
    /// </summary>
    public partial class UsunWindow : Window
    {
        public MainWindow parentWindow;
        public int PacjentID { get; set; }
        public UsunWindow(int PacjentIDDJ, MainWindow parent)
        {
            this.PacjentID = PacjentIDDJ;
            parentWindow = parent;
            InitializeComponent();
        }

        private void Tak_Click(object sender, RoutedEventArgs e)
        {   using (var db = new PacjentContext()) {
            var SelectedPacjent = db.Pacjents.Find(PacjentID);
            if (SelectedPacjent != null)
            {
               
               
                    var Pacjent = db.Pacjents.Find(SelectedPacjent.ID);
                    db.Pacjents.Remove(Pacjent);
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
