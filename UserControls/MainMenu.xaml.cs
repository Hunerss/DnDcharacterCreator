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
using Path = System.IO.Path;

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

        private void New_character_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.Navigate(new CharacterCreator(window));
        }

        private void Load_character_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "DnDCharacterCreator");

            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Character",
                DefaultExt = ".xml",
                Filter = "XML File (.xml)|*.xml",
                InitialDirectory = folderPath
            };

            bool? result = dialog.ShowDialog();

            if (result == true) 
            {
                string fileName = dialog.FileName;

                //window.frame.NavigationService.Navigate(new MainMenu(this));                
            }
        }
    }
}
