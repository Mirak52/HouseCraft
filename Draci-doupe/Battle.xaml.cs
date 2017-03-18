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
        int special = 0;
        int defBonus;
        int place1;
        Random random = new Random();
        public Battle(int place)
        {
            InitializeComponent();
            place1 = place;
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
                enemyL.Maximum = mob.Health;
                enemyL.Value = mob.Health;
            }
            var itemsFromDbPlayer = Database1.QueryGet().Result;
            foreach (var player in itemsFromDbPlayer)
            {
                playerL.Value= player.Health;
                playerL.Maximum = player.Health;
                HealthP.Content = player.Health;
                DamageP.Content = player.Damage;
                DeffP.Content = player.Deffence;      
            }
        }
        private void Action(string action)
        {
            int healtE = Convert.ToInt32(Health.Content);
            int damageE = Convert.ToInt32(Damage.Content);
            int deffE = Convert.ToInt32(Deff.Content);
            int healtP = Convert.ToInt32(HealthP.Content);
            int damageP = Convert.ToInt32(DamageP.Content);
            int deffP = Convert.ToInt32(DeffP.Content);
            
            if (action == "Attack_Click")
           {
                damageP = damageP - deffE;
                if (damageP <= 0) { damageP = 0; }
                healtE = healtE - damageP;
                life(healtP, healtE);//testuje životy
                defBonus--;
                special++;
            }
           else if (action == "Deffence_Click")
           {
                deffP = deffP * 2;
                defBonus = 2;
                special++;
            }
           else if (action == "Heal_Click")
           {
                healtP = healtP + 50 + deffP;
                special++;
            }
           else if (action == "Special_Click")
           {
                damageP = damageP * 2 - deffE;
                if (damageP <= 0) { damageP = 0; }
                healtE = healtE - damageP;
                life(healtP, healtE);//testuje životy
                defBonus--;
                special = 0;
                defBonus--;
            }
            damageE = damageE - deffP;
            if (damageE <= 0) { damageE = 0; }
            healtP = healtP - damageE;
           //testuje životy

            Health.Content = healtE;
            enemyL.Value = healtE;
            playerL.Value = healtP;
            specialP.Value = special;
            life(healtP, healtE);
            if (special >= 5){ Special.Visibility = Visibility.Visible;} else { Special.Visibility = Visibility.Hidden; }
            if(defBonus== 0){
                deffP = deffP / 2;
            }
        }

        private void life(int lifeP, int lifeE)
        {
            if (lifeP <= 0)
            {
                MessageBox.Show("Trošku si to podcenil omdlel si");
            }
            else if (lifeE <= 0)
            {
                MessageBox.Show("Gratuluji vyhrál si");
          
                }
               
                if (lifeP <= 0 | lifeE <= 0)
                {
                    reload.Visibility = Visibility.Visible;
                    back.Visibility = Visibility.Visible;
                    Attack.Visibility = Visibility.Hidden;
                    Deffence.Visibility = Visibility.Hidden;
                    Heal.Visibility = Visibility.Hidden;
                    Special.Visibility = Visibility.Hidden;
                }
            }
        

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            Action("Attack_Click");
        }

        private void Deffence_Click(object sender, RoutedEventArgs e)
        {
            Action("Deffence_Click");
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            Action("Heal_Click");
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            Action("Special_Click");
        }
        public static EnemiesDatabase _database;
        public static OsobyDatabase _database1;
       
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
        public static InventoryDatabase _database2;
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
            /*ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/picture/" + picture + ".jpg", UriKind.Absolute));
            this.Background = myBrush;*/
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            Battle customization = new Battle(place1);
            customization.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var itemsFromDb5 = Database2.QueryGet().Result;
            foreach (var inventory in itemsFromDb5)
            {

                  Inventory inv = new Inventory();
                   inv.ID = inventory.ID;
                   inv.Stone = inventory.Stone;
                   inv.Wood = inventory.Wood;
                   inv.Brick = inventory.Brick;
                   inv.Sand = inventory.Sand;
                   inv.Glass = inventory.Glass;
                   inv.Seeds = inventory.Seeds;
                   inv.Money = Convert.ToInt32(Price.Content);
                   Database2.SaveItemAsync(inv);
                
                Map customization = new Map();
                customization.Show();
                this.Close();
            }
        }
    }
}
