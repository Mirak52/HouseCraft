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
    /// Interaction logic for Market.xaml
    /// </summary>
    public partial class Market : Window
    {
        int brick;
        int seed;
        int glass;
        int sand;
        int money;
        public Market()
        {
            InitializeComponent();
            Shop(0);

        }

        public void Shop(int info)
        {
           var itemsFromDb = Database1.QueryGet().Result;
                foreach (var inventory in itemsFromDb)
                {
                 
                    int money1 = inventory.Money + money;
                    if (info == 1 & money1 >= 30){brick++;money = money - 30;}
                    if (info == 2 & money1 >= 15){money = money - 15;sand++;}
                    if (info == 3 & money1 >= 5) { money = money - 5; seed++;}
                    if (info == 4 & money1 >= 100) { money = money - 100; glass++; }
                    else if (info == 1 & money1 < 30 | info == 2 & money1 < 15 | info == 3 & money1 < 5 |
                             info == 4 & money1 < 100)
                    {
                        Warning.Content = "Nemáš dostatek peněz";
                    }
                    else{Warning.Content = "";}
                    money1 = inventory.Money + money;
                    Brick.Content = inventory.Brick + brick;
                    Sand.Content = inventory.Sand + sand;
                    Glass.Content = inventory.Glass + glass;
                    Seeds.Content = inventory.Seeds + seed;
                    Money.Content = "Aktualně máš: " + money1;
                    if (info == 5)
                    {
                    
                        Inventory inv = new Inventory();
                        inv.Stone= inventory.Brick + brick;
                        inv.Sand = inventory.Sand + sand;
                        inv.Glass = inventory.Glass + glass;
                        inv.Seeds = inventory.Seeds + seed;
                        inv.Stone = inventory.Stone;
                        inv.Wood = inventory.Wood;
                        inv.ID = inventory.ID;
                        inv.Money = money1;
                        Database1.SaveItemAsync(inv);
                        Market customization = new Market();
                        customization.Show();
                         this.Close();
                }
                }
            
        }
        private void BrickB_Click(object sender, RoutedEventArgs e)
        {
            Shop(1);
        }

        private void SandB_Click(object sender, RoutedEventArgs e)
        {
            Shop(2);
        }

        private void SeedsB_Click(object sender, RoutedEventArgs e)
        {
            Shop(3);
        }

        private void glassB_Click(object sender, RoutedEventArgs e)
        {
            Shop(4);
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Shop(5);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            City customization = new City();
            customization.Show();
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
