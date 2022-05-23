using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.Entity;
using System.Data.Entity.Core.Common;



namespace Przychodnia_v4
{
    internal class SQLiteConfig:DbConfiguration
    {
        public SQLiteConfig()
        {
            SetProviderFactory("Stystem.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("Stystem.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("Stystem.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
}
