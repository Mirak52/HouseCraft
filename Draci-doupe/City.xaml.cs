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

namespace Draci_doupe
{
    /// <summary>
    /// Interaction logic for City.xaml
    /// </summary>
    public partial class City : Window
    {
        public City()
        {
            InitializeComponent();
        }

        private void map_Click(object sender, RoutedEventArgs e)
        {
            Map move = new Map();
            move.Show();
            this.Close();
        }

        private void Hospoda_Click(object sender, RoutedEventArgs e)
        {
            Tavern move = new Tavern();
            move.Show();
            this.Close();
        }

        private void Dum_Click(object sender, RoutedEventArgs e)
        {
            House move = new House();
            move.Show();
            this.Close();
        }

        private void Obchodnik_Click(object sender, RoutedEventArgs e)
        {
            Market customization = new Market();
            customization.Show();
            this.Close();
        }
    }
}
