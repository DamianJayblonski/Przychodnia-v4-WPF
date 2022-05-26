﻿using System;
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
        public static List<Wizyta> GetRozpoznianie(int PacjentIDDJ)
        {
            var list = new List<Wizyta>();
            var Wizytka = new Wizyta();
            using (var db = new PacjentContext())
            {
                foreach (var rozpoznanie in db.Rozpoznanies)
                {
                    if (rozpoznanie.PacjentID == PacjentIDDJ || PacjentIDDJ == 0)
                    {
                        Wizytka.ID = rozpoznanie.ID;
                        Wizytka.PacjentID = rozpoznanie.PacjentID;
                        Wizytka.Nazwa = rozpoznanie.Nazwa;
                        Wizytka.RodzajZabieguID = rozpoznanie.RodzajZabieguID;
                        Wizytka.Data = rozpoznanie.Data;
                        foreach (var zabieg in db.RodzajZabiegus)
                        {
                            if(zabieg.ID == rozpoznanie.RodzajZabieguID)
                                Wizytka.NazwaZabiegu = zabieg.Nazwa;
                        }
                        
                        list.Add(Wizytka);
                    }
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







    }
    
}
