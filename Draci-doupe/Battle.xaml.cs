using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Draci_doupe.Tridy;
using Draci_doupe.Třídy;
using SQLite;
namespace Draci_doupe
{
    /// <summary>
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        Random random = new Random();
        public Battle(int place)
        {
            InitializeComponent();
            background(place);
            switch (place)
            {
                case 1:
                    int rnd = random.Next(2,5); //přidat tlačítko na reload
                    place = rnd;
                    break;
                case 2:
                    rnd = random.Next(8,9);
                    place = rnd;
                    break;
            }
            var itemsFromDb = Database.GetItemsFromDatabase(place).Result;
            foreach (var mob in itemsFromDb)
            {
                Enemy.Content = mob.Name;
                Stats.Content = "Životy: " + mob.Health + " Poškození: " + mob.Damage + " Obrana: " + mob.Deffence +
                                " Odměna: " + mob.Price;
                Health.Content = mob.Health;
                Damage.Content = mob.Damage;
                Deff.Content = mob.Deffence;
                Price.Content = mob.Price;
            }

        }

        private void Action(string action)
        {
            
        }



        public static EnemiesDatabase _database;
        public static OsobyDatabase _database1;
        public static InventoryDatabase _database2;
        public static EnemiesDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new Filehelper();
                    _database = new EnemiesDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
        public static OsobyDatabase Database1
        {
            get
            {
                if (_database1 == null)
                {
                    var fileHelper = new Filehelper();
                    _database1 = new OsobyDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database1;
            }
        }
        public static InventoryDatabase Database2
        {
            get
            {
                if (_database1 == null)
                {
                    var fileHelper = new Filehelper();
                    _database2 = new InventoryDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database2;
            }
        }
        private void background(int number)
        {
            string picture = "";
            switch (number)
            {
                case 0:
                    picture = "";
                    break;
                case 1:
                    picture = "pirateBay";
                    break;
            }
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/picture/" + picture + ".jpg", UriKind.Absolute));
            this.Background = myBrush;
        }
    }
}
