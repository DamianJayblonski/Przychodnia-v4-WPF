using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Przychodnia_v2;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Przychodnia_v4
{/*
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytuj.xaml
    /// </summary>
    public partial class DodajEdytuj : INotifyPropertyChanged
    {
        public DodajEdytuj()
        {
            DataContext = this;
            InitializeComponent();
        }
        private string _boundName;
        public string BoundName
        {
            get { return _boundName; }
            set
            {
                _boundName = value;
                OnPropertyChanged();
            }
        }

        public event DependencyPropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PacjentContext())
            {

                db.Add(new Pacjent()
                {
                    Nazwisko = "Jasiński",
                    Imie = "Marcel",
                    Adres = "ul. Błotna numer zakrapiany Krakow woj. Mał",
                    DataUrodzenia = new DateTime(1978, 1, 18, 0, 0, 0),
                    Plec = "M",
                    Pesel = "76011812222"
                });
                db.SaveChanges();
            }
        }

    }*/
}