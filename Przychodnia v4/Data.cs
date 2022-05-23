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
    }
    
}
