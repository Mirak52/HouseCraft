using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Draci_doupe.Tridy
{
   public class Requirement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Stone { get; set; }
        public int Wood { get; set; }
        public int Money { get; set; }
        public int Brick { get; set; }
        public int Sand { get; set; }
        public int Glass { get; set; }
        public int Seeds { get; set; }
    }
}
