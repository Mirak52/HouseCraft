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
using System.Windows.Shapes;
using Draci_doupe.Tridy;
using Draci_doupe.Třídy;

namespace Draci_doupe
{
    /// <summary>
    /// Interaction logic for House.xaml
    /// </summary>
    public partial class House : Window
    {
        public House()
        {
            InitializeComponent();
            Build();
            
        }

        public void Build()
        {
            var items = Database2.QueryGet().Result;
            foreach (var level in items)
            {
                var itemsFromDb1 = Database1.QueryGet().Result;
                foreach (var inventar in itemsFromDb1)
                {
                    var itemsFromDb = Database.GetItemsFromDatabase(level.LevelHouse).Result;
                    foreach (var pozadavek in itemsFromDb)
                    {
                        Needs.Content = "Požadavek/máš   Dřevo: " + pozadavek.Wood + "/" + inventar.Wood + " Kámen: " + pozadavek.Stone +
                                        "/" + inventar.Stone + " Cihly: " + pozadavek.Brick + "/" + inventar.Brick +
                                        " Písek: " + pozadavek.Sand + "/" + inventar.Sand + " sklo: " + pozadavek.Glass +
                                        "/" + inventar.Glass + " Semínka: " + pozadavek.Seeds + "/" + inventar.Seeds +
                                        " Cena: " + pozadavek.Money + "/" + inventar.Money +" Ukoly: " + pozadavek.Quest +"/" + level.Quest;
                        if (pozadavek.Wood <= inventar.Wood & pozadavek.Stone <= inventar.Stone &
                            pozadavek.Brick <= inventar.Brick & pozadavek.Sand <= inventar.Sand &
                            pozadavek.Glass <= inventar.Glass & pozadavek.Seeds <= inventar.Seeds &
                            pozadavek.Money <= inventar.Money & pozadavek.Quest <= level.Quest)
                        {
                            Upgrade.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }
 

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var itemsFromDb1 = Database2.QueryGet().Result;
            foreach (var house in itemsFromDb1)
            {
                Osoby houseLevel = new Osoby();
                houseLevel.ID = house.ID;
                houseLevel.Chopping = house.Chopping;
                houseLevel.Damage = house.Damage;
                houseLevel.Deffence = house.Deffence;
                houseLevel.Health = house.Health;
                houseLevel.Level = house.Level;
                houseLevel.Mining = house.Mining;
                houseLevel.LevelHouse = house.LevelHouse + 1;
                house.Quest = house.Quest;
                Database2.SaveItemAsync(houseLevel);
               
            }
            Upgrade.Visibility = Visibility.Hidden;
            Build();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            City move = new City();
            move.Show();
            this.Close();
        }
        public static InventoryDatabase _database1;
        public static InventoryDatabase Database1
        {
            get
            {
                if (_database1 == null)
                {
                    var fileHelper = new Filehelper();
                    _database1 = new InventoryDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database1;
            }
        }
        public static RequirementDatabase _database;
        public static RequirementDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new Filehelper();
                    _database = new RequirementDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
        public static OsobyDatabase _database2;
        public static OsobyDatabase Database2
        {
            get
            {
                if (_database2 == null)
                {
                    var fileHelper = new Filehelper();
                    _database2 = new OsobyDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database2;
            }
        }
    }
 }
