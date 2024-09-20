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
    /// Logika interakcji dla klasy CharacterCreator.xaml
    /// </summary>
    public partial class CharacterCreator : UserControl
    {
        MainWindow window;
        public CharacterCreator(MainWindow win)
        {
            InitializeComponent();
            window = win;
        }

        private void radnomName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClassesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SubclassesComboBox.Items.Clear();

            string selectedClass = (ClassesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selectedClass)
            {
                case "Barbarian":
                    SubclassesComboBox.Items.Add("Berserker");
                    SubclassesComboBox.Items.Add("Totem Warrior");
                    SubclassesComboBox.Items.Add("Ancestral Guardian");
                    SubclassesComboBox.Items.Add("Storm Herald");
                    break;
                case "Bard":
                    SubclassesComboBox.Items.Add("College of Lore");
                    SubclassesComboBox.Items.Add("College of Valor");
                    SubclassesComboBox.Items.Add("College of Glamour");
                    SubclassesComboBox.Items.Add("College of Whispers");
                    break;
                case "Wizard":
                    SubclassesComboBox.Items.Add("School of Evocation");
                    SubclassesComboBox.Items.Add("School of Illusion");
                    SubclassesComboBox.Items.Add("School of Necromancy");
                    SubclassesComboBox.Items.Add("School of Transmutation");
                    break;
                case "Druid":
                    SubclassesComboBox.Items.Add("Circle of the Moon");
                    SubclassesComboBox.Items.Add("Circle of the Land");
                    SubclassesComboBox.Items.Add("Circle of Spores");
                    SubclassesComboBox.Items.Add("Circle of Stars");
                    break;
                case "Rogue":
                    SubclassesComboBox.Items.Add("Thief");
                    SubclassesComboBox.Items.Add("Assassin");
                    SubclassesComboBox.Items.Add("Arcane Trickster");
                    SubclassesComboBox.Items.Add("Swashbuckler");
                    break;
                case "Paladin":
                    SubclassesComboBox.Items.Add("Oath of Devotion");
                    SubclassesComboBox.Items.Add("Oath of Vengeance");
                    SubclassesComboBox.Items.Add("Oath of the Ancients");
                    SubclassesComboBox.Items.Add("Oath of Conquest");
                    break;
                case "Cleric":
                    SubclassesComboBox.Items.Add("Life Domain");
                    SubclassesComboBox.Items.Add("War Domain");
                    SubclassesComboBox.Items.Add("Trickery Domain");
                    SubclassesComboBox.Items.Add("Knowledge Domain");
                    break;
                case "Fighter":
                    SubclassesComboBox.Items.Add("Champion");
                    SubclassesComboBox.Items.Add("Battle Master");
                    SubclassesComboBox.Items.Add("Eldritch Knight");
                    SubclassesComboBox.Items.Add("Arcane Archer");
                    break;
                case "Warlock":
                    SubclassesComboBox.Items.Add("The Fiend");
                    SubclassesComboBox.Items.Add("The Great Old One");
                    SubclassesComboBox.Items.Add("The Hexblade");
                    SubclassesComboBox.Items.Add("The Genie");
                    break;
                case "Monk":
                    SubclassesComboBox.Items.Add("Way of the Open Hand");
                    SubclassesComboBox.Items.Add("Way of Shadow");
                    SubclassesComboBox.Items.Add("Way of the Four Elements");
                    SubclassesComboBox.Items.Add("Way of the Drunken Master");
                    break;
            }
        }

        private void roll_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ability_scores_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ability_scores_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void strength_button_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void strength_button_remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
