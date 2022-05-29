using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przychodnia_v2;

namespace Przychodnia_v4
{
    public class Data
    {
        public static List<Pacjent> GetPacjents() 
        {
            var list = new List<Pacjent>();
            using(var db = new PacjentContext())
            {
                foreach(var pacjent in db.Pacjents)
                {
                   list.Add(pacjent);
                }
                return list;
            }
        }
        public static List<Rozpoznanie> GetRozpoznianie()
        {
            var list = new List<Rozpoznanie>();
            using (var db = new PacjentContext())
            {
                foreach (var rozpoznanie in db.Rozpoznanies)
                {
                    foreach (var zabieg in db.RodzajZabiegus)
                    {
                        if (zabieg.ID == rozpoznanie.RodzajZabieguID)
                            rozpoznanie.RodzajZabiegu.Nazwa = zabieg.Nazwa;
                    }
                    list.Add(rozpoznanie);
                }
                return list;
            }
        }

        public static List<Wypis> GetWypis()
        {
            var list = new List<Wypis>();
            using (var db = new PacjentContext())
            {
                foreach (var wypis in db.Wypiss)
                {
                    list.Add(wypis);
                }
                return list;
            }
        }

        public static List<RodzajZabiegu> GetZabieg()
        {
            var list = new List<RodzajZabiegu>();
            using (var db = new PacjentContext())
            {
                foreach (var zabieg in db.RodzajZabiegus)
                {
                    list.Add(zabieg);
                }
                return list;
            }
        }







    }
    
}
