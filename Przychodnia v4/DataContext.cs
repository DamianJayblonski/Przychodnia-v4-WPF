using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przychodnia_v2;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace Przychodnia_v4
{/*
    public class DataContext:DbContext
    {
        public DataContext() : base(new SQLiteConnection()
        {

            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "Przychodnia01.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        { 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pacjent> Pacjents { get; set; }
    }
    */
}

