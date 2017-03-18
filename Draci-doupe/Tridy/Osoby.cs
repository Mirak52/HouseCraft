using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
namespace Draci_doupe.Třídy
{
    public class Osoby
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Deffence { get; set; }
        public int Mining { get; set; }
        public int Chopping { get; set; }
        public int Level { get; set; }
        
        public int LevelHouse { get; set; }
        public int Quest { get; set; }
        public Osoby()
        {
        }
        
    }
}
