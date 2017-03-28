using Draci_doupe.Třídy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Draci_doupe
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static OsobyDatabase _database;

        public static OsobyDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new Filehelper();
                    _database = new OsobyDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
    }
}
