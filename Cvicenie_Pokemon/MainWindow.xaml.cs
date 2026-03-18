using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cvicenie_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hero myHero = new Hero(100, 100, 10, 100, 10, 15, 10);
            Enemy enemy = new Enemy(200, 200, 10);

            Window_Fight fight_window = new Window_Fight(myHero, enemy);
            fight_window.Show();

 
        }

    }
}