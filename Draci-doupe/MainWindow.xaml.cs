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

namespace Draci_doupe
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private static OsobyDatabase _database;

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
        private static InventoryDatabase _database1;

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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            Osoby item = new Osoby();
            item.Chopping = 1;
            item.Damage = 1;
            item.Deffence = 1;
            item.Level = 1;
            item.Mining = 1;
            item.LevelHouse = 1;
            item.Quest = 1;
            item.Health = 100;
            Database.SaveItemAsync(item);
            Inventory data = new Inventory();
            Database1.SaveItemAsync(data);
           
            Info customization = new Info();
            customization.Show();
            this.Close();
          
        }
        private void End_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
           
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            int place = 1;
            Resources customization = new Resources(place);
            customization.Show();
            this.Close();
        }
    }
}
