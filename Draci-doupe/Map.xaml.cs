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
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
        }
        private void Forest_Click(object sender, RoutedEventArgs e)
        {
            int place = 0;
            Resources customization = new Resources(place);
            customization.Show();
            this.Close();
        }
        private void Quarry_Click(object sender, RoutedEventArgs e)
        {
            int place = 1;
            Resources customization = new Resources(place);
            customization.Show();
            this.Close();
        }

        private void City_Click(object sender, RoutedEventArgs e)
        {
            City customization = new City();
            customization.Show();
            this.Close();
        }
    }
}
