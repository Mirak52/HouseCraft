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
        

        public Tavern()
        {
            /*Inventory Skills = new Inventory();
            Skills.Money = 500;
            Database2.SaveItemAsync(Skills);*/
            InitializeComponent();
            var itemsFromDb = App.Database.QueryGet().Result;
            foreach (var variable in itemsFromDb)
            {
                var itemsFromDb1 = Database1.GetItemsFromDatabase(variable.Quest).Result;
                foreach (var drby in itemsFromDb1)
                {
                    if (drby.ID == 6)
                    {
                        Text.Content = "Všechny ukoly splněny";
                        Accept.Visibility = Visibility.Hidden;
                    }
                    else { 
                    Text.Content = drby.text;
                    }

                }
            }
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
                    gold.Content = osoby.Money - 5;
                    Inventory Skills = new Inventory();
                    Skills.Money = osoby.Money - 5;
                    Skills.Stone = osoby.Stone;
                    Skills.Brick = osoby.Glass;
                    Skills.ID = osoby.ID;
                    Skills.Sand = osoby.Sand;
                    Skills.Wood = osoby.Wood;
                    Skills.Seeds = osoby.Seeds;
                    Database2.SaveItemAsync(Skills);
                    
                }
                if(osoby.Money <= 5){Beer.Visibility = Visibility.Hidden;}
               
               if (command == 3)
               {
                   Accept.Visibility = Visibility.Visible;
          

               }
                if (command == 4)
                {
                    var itemsFromDb2 = App.Database.QueryGet().Result;
                    foreach (var variable in itemsFromDb2)
                    {
                        var itemsFromDb1 = Database1.GetItemsFromDatabase(variable.Quest).Result;
                        foreach (var quest in itemsFromDb1)
                        {
                            Battle customization = new Battle(quest.enemy);
                            customization.Show();
                            this.Close();
                        }
                    }
                }
                command = 0;
            }
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


        public static GossipDatabase _database1;
        public static InventoryDatabase _database2;
       
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
                if (_database2 == null)
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
