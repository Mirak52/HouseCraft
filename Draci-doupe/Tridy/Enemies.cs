using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Draci_doupe.Tridy
{
    public class Enemies
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Deffence { get; set; }
        public int Price { get; set; }

    }
}
