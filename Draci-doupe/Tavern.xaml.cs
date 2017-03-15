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
using SQLite;
using Draci_doupe.Tridy;
using Draci_doupe.Třídy;

namespace Draci_doupe
{
    /// <summary>
    /// Interaction logic for Tavern.xaml
    /// </summary>
    /// 

    public partial class Tavern : Window
    {
        Random random = new Random();

        public Tavern()
        {
            /*Inventory Skills = new Inventory();
            Skills.Money = 500;
            Database2.SaveItemAsync(Skills);*/
            InitializeComponent();
            Money(0);

        }
        public void Money(int command)
        {
            var itemsFromDb = Database2.QueryGet().Result;
            foreach (var osoby in itemsFromDb)
            {
                gold.Content = osoby.Money;
                

                if(command == 1)
                {
                    gold.Content = osoby.Money - 20;
                    Inventory Skills = new Inventory();
                    Skills.Money = osoby.Money - 20;
                    Skills.Stone = osoby.Stone;
                    Skills.Brick = osoby.Glass;
                    Skills.ID = osoby.ID;
                    Skills.Sand = osoby.Sand;
                    Skills.Wood = osoby.Wood;
                    Skills.Seeds = osoby.Seeds;
                    Database2.SaveItemAsync(Skills);
                    
                }
                if(osoby.Money <= 20){Beer.Visibility = Visibility.Hidden;}
                if(command == 2)
                {
                    int rnd = random.Next(1,4);
                    var itemsFromDb1 = Database1.GetItemsFromDatabase(rnd).Result;
                    foreach (var drby in itemsFromDb1)
                    {
                        Text.Content = drby.text;
                    }
                 }
               if (command == 3)
               {
                   Accept.Visibility = Visibility.Visible;
          

               }
                if (command == 4)
                {
                    
                }
                command = 0;
            }
        }
        private void gossip_Click(object sender, RoutedEventArgs e)
        {
            Money(2);
        }
        private void quest_Click(object sender, RoutedEventArgs e)
        {
            Money(3);
        }
        private void Beer_Click(object sender, RoutedEventArgs e)
        {
            Money(1); //přidat 
        }
        private void City_Click(object sender, RoutedEventArgs e)
        {
            City customization = new City();
            customization.Show();
            this.Close();
        }



        public static EnemiesDatabase _database;
        public static GossipDatabase _database1;
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
        public static GossipDatabase Database1
        {
            get
            {
                if (_database1 == null)
                {
                    var fileHelper = new Filehelper();
                    _database1 = new GossipDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
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

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Money(4);
        }
    }
}
