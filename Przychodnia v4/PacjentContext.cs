using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia_v2
{
    public class PacjentContext : DbContext
    {
        public DbSet<Pacjent> Pacjents { get; set; }
        public DbSet<Rozpoznanie> Rozpoznanies { get; set; }
        public DbSet<Wypis> Wypiss { get; set; }
        public DbSet<RodzajZabiegu> RodzajZabiegus { get; set; }

        public string DbPath { get; }

        public PacjentContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path,"Przychodnia\\Przychodnia01.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            Console.WriteLine(DbPath);
            // dbContextOptionsBuilder.UseSqlite("Data Source =pacjent04.db");
            dbContextOptionsBuilder.UseSqlite($"Data Source ={DbPath}");
        }

    }
    public class Pacjent
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Pesel { get; set; }
        public string Plec { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public ICollection<Rozpoznanie> Rozpoznanies { get; set; }
        public ICollection<Wypis> Wypiss { get; set; }

    }
    public class Rozpoznanie
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime Data { get; set; }
        public int RodzajZabieguID { get; set; }
        public RodzajZabiegu RodzajZabiegu { get; set; }
        public int PacjentID { get; set; }
        public Pacjent Pacjent { get; set; }
    }
    public class Wypis
    {
        public int ID { get; set; }
        public string Rezultat { get; set; }
        public DateTime DataWypisu { get; set; }
        public DateTime DataLeczeniaOd { get; set; }
        public DateTime DataLeczeniaDo { get; set; }
        public int PacjentID { get; set; }
        public Pacjent Pacjent { get; set; }
    }
    public class RodzajZabiegu
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Numer { get; set; }
        public ICollection<Rozpoznanie> Rozpoznanies { get; set; }

    }
}

