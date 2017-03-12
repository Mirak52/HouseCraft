using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Draci_doupe.Třídy;

namespace Draci_doupe
{
    /// <summary>
    /// Interaction logic for pointChoose.xaml
    /// </summary>
    public partial class pointChoose : Window
    {

        public int points = 10;
        public pointChoose()
        {
            InitializeComponent();
            show();
            Points.Content = "Aktualní počet bodů: " + points;
            //Level.Content = "Aktualní level: " + Level;
         
            var itemsFromDb = Database.QueryGet().Result;  
            foreach (var osoby in itemsFromDb)
            {
                int level = osoby.Level;
                LevelN.Content = level;
                HealthL.Content = osoby.Health;
                DamageL.Content = osoby.Damage;
                DeffenceL.Content = osoby.Deffence;
                MiningL.Content = osoby.Mining;
                ChoppingL.Content = osoby.Chopping;
            }
        }

        public void Health_Click(object sender, RoutedEventArgs e)
        {   
            HealthL.Content = (int)convertor(HealthL.Content) + 1;
        }
        private void Damage_Click(object sender, RoutedEventArgs e)
        {      
            DamageL.Content = (int)convertor(DamageL.Content) + 1;
        }
        private void Deffence_Click(object sender, RoutedEventArgs e)
        {
            DeffenceL.Content = (int)convertor(DeffenceL.Content) + 1;
        }
        private void Mining_Click(object sender, RoutedEventArgs e)
        {
            MiningL.Content = (int)convertor(MiningL.Content) + 1;
        }
        private void Chopping_Click(object sender, RoutedEventArgs e)
        {    
            ChoppingL.Content = (int)convertor(ChoppingL.Content) + 1;
        }
        
        public object convertor(object variable)
        {
            points = points - 1;
            Points.Content = "Aktualní počet bodů: " + points;
            int skill = Convert.ToInt32(variable);
            show();
            return skill;

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

        public void show() //Řeší tlačítka show/hide
        {
            if (points == 0)
            {
                Health.Visibility = Visibility.Hidden;
                Damage.Visibility = Visibility.Hidden;
                Deffence.Visibility = Visibility.Hidden;
                Mining.Visibility = Visibility.Hidden;
                Chopping.Visibility = Visibility.Hidden;
                Play.Visibility = Visibility.Hidden;
                Play.Visibility = Visibility.Visible;
            }
            else
            {
                Play.Visibility = Visibility.Hidden;
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Osoby Skills = new Osoby();
            Skills.Level = (int)convertor(LevelN.Content) + 1;
            Skills.Health = (int)convertor(HealthL.Content);
            Skills.Damage = (int)convertor(DamageL.Content);
            Skills.Deffence = (int)convertor(DeffenceL.Content);
            Skills.Mining = (int)convertor(MiningL.Content);
            Skills.Chopping = (int)convertor(ChoppingL.Content);
            Database.SaveItemAsync(Skills);
            Map Page = new Map();
            Page.Show();
            this.Close();
        }

        private void Chopping_OnMouseMove(object sender, MouseEventArgs e){Info.Content = "Zvyšuje rychlost a množství vytěžené suroviny";}
        private void Mining_OnMouseMove(object sender, MouseEventArgs e){Info.Content = "Zvyšuje rychlost a množství vytěžené suroviny";}
        private void Deffence_OnMouseMove(object sender, MouseEventArgs e){Info.Content = "Zvyšuje obranu a snižuje poškození"; }
        private void Damage_OnMouseMove(object sender, MouseEventArgs e){Info.Content = "Zvyšuje poškození v boji"; }
        private void Health_OnMouseMove(object sender, MouseEventArgs e){Info.Content = "Zvyšuje celkové životy";}
    }
}
