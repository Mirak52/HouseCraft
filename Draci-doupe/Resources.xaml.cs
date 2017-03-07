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
            var itemsFromDb = Database.QueryGet().Result;
            foreach (var osoby in itemsFromDb)
            {
                /*var itemsFromDb1 = Database1.QueryGet().Result;
                foreach (var test in itemsFromDb1)
                {
                    Current.Content = "Aktualně: " + test.Stone;
                }*/
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
            double x = 0.5;
            int max = 100;
            string place = Convert.ToString(Place.Content);
            int skill = Convert.ToInt32(Skill.Content);
            int click = max / skill;
            
            if (place == "LES")
            {
                int rnd = random.Next(skill, skill + 5);
                double resources = x * rnd;
                int test = Convert.ToInt32(resources);
                
            }
            else if (place == "DUL")
            {
                control++;
                int rnd = random.Next(skill, skill + 5);
                double resources = x * rnd;
                int test = Convert.ToInt32(resources);
                //Place.Content = click;
                if (control == click)
                {
                    Inventory item = new Inventory();
                    item.Stone = test;
                    item.Wood = 50;
                    
                    Database1.SaveItemAsync(item);
                    Bar.Value = 0;
                    control = 0;
                }
                else
                {
                    Bar.Value = Bar.Value + max / click;
                }
            }
         
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
                if (_database == null)
                {
                    var fileHelper = new Filehelper();
                    _database1 = new InventoryDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database1;
            }
        }
    }
}
