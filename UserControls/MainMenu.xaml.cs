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

namespace DnDcharacterCreator.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        MainWindow window;
        public MainMenu(MainWindow win)
        {
            this.window = win;
            InitializeComponent();
        }

        private void new_character_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.Navigate(new MainMenu(window));
        }

        private void load_character_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.Navigate(new MainMenu(window));
        }
    }
}
