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
        private static InventoryDatabase _database;

        public static InventoryDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new Filehelper();
                    _database = new InventoryDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            Inventory item = new Inventory();
            item.Stone = 5;
            Database.SaveItemAsync(item);
            

            Info customization = new Info();
            customization.Show();
            this.Close();
          
        }
        private void End_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            pointChoose test = new pointChoose();
            test.Show();
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
