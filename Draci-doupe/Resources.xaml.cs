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
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        int control = 0;
        Random random = new Random(); 
        public Resources(int place)
        {
            InitializeComponent();
            background(place);
            Show(place);
            var itemsFromDb = Database.QueryGet().Result;
            foreach (var osoby in itemsFromDb)
            {
                
                if (place == 0)
                {
                    Place.Content = "LES";
                    Skill.Content = osoby.Chopping;

                }
                else if (place == 1)
                {   
                    Place.Content = "DUL";
                    Skill.Content = osoby.Mining;
                }
            }  
        }
        private void Show(int place)
        {
            var itemsFromDb1 = Database1.QueryGet().Result;
            foreach (var data in itemsFromDb1)
            {
                if (place == 0)
                {
                    Current.Content = data.Wood;
                    ID.Content = data.ID;
                }
                else if (place == 1)
                {
                    Current.Content = data.Stone;
                    ID.Content = data.ID;
                }
            }
        }
        private void background(int number)
        {
            string picture = "map";
            switch (number)
            {
                case 0:
                    picture = "tree";
                 break;
                case 1:
                    picture = "mine";
                    break;
            }
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/picture/"+ picture +".jpg", UriKind.Absolute));
            this.Background = myBrush;
        }      
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Work();
        }

        private void Work()
        {
            int plac = 0;
            control++;
            string place = Convert.ToString(Place.Content);
            int skill = Convert.ToInt32(Skill.Content) /2;
            if (control == 5)
            {
                Inventory item = new Inventory();
                int current = Convert.ToInt32(Current.Content);
                item.ID = Convert.ToInt32(ID.Content);
                if (place == "LES")
                {
                    Show(plac);
                    item.Wood = skill + current;
                }
                else if (place == "DUL")
                {
                    plac = 1;
                    Show(plac);
                    item.Stone = skill + current;
                }
                Database1.SaveItemAsync(item);
                control = 0;
            }
            Bar.Value = 20 * control;
        }
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

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            Map page = new Map();
            page.Show();
            this.Close();
        }
    }
}
