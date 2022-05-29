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
    /// Logika interakcji dla klasy DodajEdytujHistorie.xaml
    /// </summary>
    public partial class DodajEdytujHistorie : Window
    {
        public int PacjentID { get; set; }
        public int HistoriaID { get; set; }
        public string Rezultat { get; set; }
        public DateTime DataLeczeniaOd { get; set; }
        public DateTime DataLeczeniaDo { get; set; }
        public DateTime DataWypisu { get; set; }
        public MainWindow parentWindow;

        public DodajEdytujHistorie(int HistoriaIDDJ,int PacjentIDDJ , MainWindow parent)
        {
            this.PacjentID = PacjentIDDJ;
            this.HistoriaID = HistoriaIDDJ;
            if(HistoriaID > 0)
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
                var SelectedHistoria = db.Wypiss.Find(HistoriaID);
                PacjentID = SelectedHistoria.PacjentID;
                DataLeczeniaDo = SelectedHistoria.DataLeczeniaDo;
                DataLeczeniaOd = SelectedHistoria.DataLeczeniaOd;
                DataWypisu = SelectedHistoria.DataWypisu;
                Rezultat = SelectedHistoria.Rezultat;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PacjentContext())
            {
                if (HistoriaID > 0)
                {

                    var SelectedHistoria = db.Wypiss.Find(HistoriaID);
                    SelectedHistoria.PacjentID = this.PacjentID;
                    SelectedHistoria.DataLeczeniaDo = this.DataLeczeniaDo;
                    SelectedHistoria.DataLeczeniaOd = this.DataLeczeniaOd;
                    SelectedHistoria.DataWypisu = this.DataWypisu;
                    SelectedHistoria.Rezultat = this.Rezultat;
                    db.SaveChanges();


                }
                else
                {
                    db.Add(new Wypis()
                    {
                   PacjentID = this.PacjentID,
                   DataLeczeniaDo = this.DataLeczeniaDo,
                   DataLeczeniaOd = this.DataLeczeniaOd,
                   DataWypisu = this.DataWypisu,
                   Rezultat = this.Rezultat


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
