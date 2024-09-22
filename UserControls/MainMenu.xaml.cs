using DnDcharacterCreator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
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
                try
                {
                    XmlSerializer serializer = new(typeof(Character));
                    using StreamReader reader = new(fileName);
                    Character character = (Character)serializer.Deserialize(reader);
                    window.frame.NavigationService.Navigate(new Summary(window, character));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading character: {ex.Message}");
                }
            }
        }
    }
}
