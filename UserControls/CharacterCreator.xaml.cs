using DnDcharacterCreator.Classes;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DnDcharacterCreator.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy CharacterCreator.xaml
    /// </summary>
    public partial class CharacterCreator : UserControl
    {
        MainWindow window;
        Random rnd = new();
        int availablePoints = 26;

        string selectedRace;

        public CharacterCreator(MainWindow win)
        {
            InitializeComponent();
            window = win;
        }

        private void radnomName_Click(object sender, RoutedEventArgs e)
        {
            int v = selectedRace.ToLower() switch
            {
                "human" => 0,
                "elf" => 1,
                "dwarf" => 2,
                "halfling" => 3,
                "dragonborn" => 4,
                "gnome" => 5,
                "half-elf" => 6,
                "half-orc" => 7,
                "tiefling" => 8,
                "aasimar" => 9,
                _ => -1,
            };
            characterName.Text = GenerateRandomName(v);
        }

        private string GenerateRandomName(int raceId)
        {
            string[,] raceNames = new string[,]
            {
                // Human Names
                { "Alaric", "Seraphina", "Cedric", "Elara", "Magnus", "Livia", "Thorne", "Isolde", "Jarek", "Mira" },
    
                // Elf Names
                { "Arannis", "Lirael", "Thalion", "Elysia", "Fenrin", "Sylvara", "Kaelith", "Aelwen", "Vanyar", "Nymeria" },
    
                // Dwarf Names
                { "Balin", "Dvalin", "Tordek", "Keldorn", "Bruni", "Gilda", "Orin", "Thrain", "Helga", "Faldur" },
    
                // Halfling Names
                { "Milo", "Pippin", "Daisy", "Tansy", "Marigold", "Nibbles", "Rolly", "Fennel", "Tilly", "Boddynock" },
    
                // Dragonborn Names
                { "Tharivol", "Kaida", "Raxivor", "Sythorn", "Zephyra", "Drakkon", "Gryzkal", "Xalvador", "Korrath", "Valzarek" },
    
                // Gnome Names
                { "Boddynock", "Zook", "Nimblefoot", "Fizzlebang", "Tinker", "Lilli", "Dabble", "Quibble", "Wizzle", "Bimble" },
    
                // Half-Elf Names
                { "Elyndra", "Caldor", "Rhiannon", "Kael", "Mirelle", "Jareth", "Thalia", "Lyra", "Alenor", "Drystan" },
    
                // Half-Orc Names
                { "Grom", "Thok", "Urga", "Krak", "Zug", "Sharn", "Brog", "Varg", "Ruk", "Gore" },
    
                // Tiefling Names
                { "Zariel", "Astaroth", "Lucian", "Keziah", "Thorne", "Nyx", "Leliana", "Riven", "Sable", "Carmen" },
    
                // Aasimar Names
                { "Seraphiel", "Celestia", "Dawn", "Mirael", "Uriel", "Zophiel", "Liora", "Elysium", "Solara", "Gideon" }
            };
            return raceNames[raceId,rnd.Next(0,10)];
        }

        private void SetWindow()
        {
            int race = rnd.Next(0, 9);
            RacesComboBox.SelectedIndex = race;
            ClassesComboBox.SelectedIndex = rnd.Next(0,9);
            SubclassesComboBox.SelectedIndex = rnd.Next(0,4);
            characterName.Text = GenerateRandomName(race);
        }

        private void ClassesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedClass = (ClassesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            ShowSpellcastingAbilityForClass(selectedClass);
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

        private void ShowSpellcastingAbilityForClass(string selectedClass)
        {
            string[] spellcastingClasses = { "Bard", "Cleric", "Druid", "Sorcerer", "Warlock", "Wizard", "Paladin", "Ranger" };

            if (Array.Exists(spellcastingClasses, element => element == selectedClass))
            {
                spellcasting_ability_text.Visibility = Visibility.Visible;
                spellcasting_ability.Visibility = Visibility.Visible;

                spellcasting_ability.Text = selectedClass switch
                {
                    "Bard" => "Charisma",
                    "Cleric" => "Wisdom",
                    "Druid" => "Wisdom",
                    "Sorcerer" => "Charisma",
                    "Warlock" => "Charisma",
                    "Wizard" => "Intelligence",
                    "Paladin" => "Charisma",
                    "Monk" => "Wisdom",
                    _ => "Unknown"
                };
            }
            else
            {
                spellcasting_ability.Text = "IDK";
                spellcasting_ability_text.Visibility = Visibility.Hidden;
                spellcasting_ability.Visibility = Visibility.Hidden;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int[,] hitpoints = new int[,]
            {
                { 7, 12 },
                { 5, 8 },
                { 4, 6 },
                { 5, 8 },
                { 5, 8 },
                { 6, 10 },
                { 5, 8 },
                { 6, 10 },
                { 5, 8 },
                { 5, 8 }
            };
            ComboBoxItem comboBoxItem = ClassesComboBox.SelectedItem as ComboBoxItem;
            string selectedClass = comboBoxItem.Content.ToString();
            int v = selectedClass switch
            {
                "Barbarian" => 0,
                "Bard" => 1,
                "Wizard" => 2,
                "Druid" => 3,
                "Rogue" => 4,
                "Paladin" => 5,
                "Cleric" => 6,
                "Fighter" => 7,
                "Warlock" => 8,
                "Monk" => 9,
                _ => -1,
            };
            string btn_name = ((Button)sender).Name;
            if (btn_name[..^7] == "avreage")
                hitpoints_textbox.Text = hitpoints[v, 0].ToString();
            else if (btn_name[..^7] == "max")
                hitpoints_textbox.Text = hitpoints[v, 1].ToString();
            else
                Console.WriteLine("Error");
        }

        private void ability_scores_DropDownClosed(object sender, EventArgs e)
        {
            ComboBoxItem comboBoxItem = ability_scores.SelectedItem as ComboBoxItem;
            if (comboBoxItem.Name == "custom")
            {
                points.Visibility = Visibility.Hidden;
            }
            else if (comboBoxItem.Name == "point_buy")
            {
                points.Visibility = Visibility.Visible;
                UpdatePointDisplay();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TextBox associatedTextBox = GetAssociatedTextBox(button);
            if (associatedTextBox != null)
            {
                int currentValue = int.Parse(associatedTextBox.Text);
                if (ability_scores.SelectedItem is ComboBoxItem selectedItem)
                {
                    if (selectedItem.Name == "custom")
                    {
                        if (currentValue < 15)
                        {
                            associatedTextBox.Text = (currentValue + 1).ToString();
                            UpdateButtonStates();
                        }
                    }
                    else if (selectedItem.Name == "point_buy")
                    {
                        if (currentValue < 15 && availablePoints > 0)
                        {
                            associatedTextBox.Text = (currentValue + 1).ToString();
                            availablePoints--;
                            UpdatePointDisplay();
                            UpdateButtonStates();
                        }
                    }
                }
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TextBox associatedTextBox = GetAssociatedTextBox(button);
            if (associatedTextBox != null)
            {
                int currentValue = int.Parse(associatedTextBox.Text);
                if (ability_scores.SelectedItem is ComboBoxItem selectedItem)
                {
                    if (selectedItem.Name == "custom")
                    {
                        if (currentValue > 8)
                        {
                            associatedTextBox.Text = (currentValue - 1).ToString();
                            UpdateButtonStates();
                        }
                    }
                    else if (selectedItem.Name == "point_buy")
                    {
                        if (currentValue > 8)
                        {
                            associatedTextBox.Text = (currentValue - 1).ToString();
                            availablePoints++;
                            UpdatePointDisplay();
                            UpdateButtonStates();
                        }
                    }
                }
            }
        }

        private void UpdatePointDisplay()
        {
            remaining_points.Text = availablePoints.ToString();
        }

        private void UpdateButtonStates()
        {
            UpdateButtonState(strength_textbox);
            UpdateButtonState(dexterity_textbox);
            UpdateButtonState(constitution_textbox);
            UpdateButtonState(inteligence_textbox);
            UpdateButtonState(wisdom_textbox);
            UpdateButtonState(charisma_textbox);
        }

        private void UpdateButtonState(TextBox textBox)
        {
            int value = int.Parse(textBox.Text);
            Button addButton = GetAddButton(textBox);
            Button removeButton = GetRemoveButton(textBox);

            addButton.IsEnabled = value < 15 && (ability_scores.SelectedItem is ComboBoxItem item && item.Name == "custom" || availablePoints > 0);
            removeButton.IsEnabled = value > 8;
        }

        private Button GetAddButton(TextBox textBox)
        {
            if (textBox == strength_textbox) return strength_button_add;
            if (textBox == dexterity_textbox) return dexterity_button_add;
            if (textBox == constitution_textbox) return constitution_button_add;
            if (textBox == inteligence_textbox) return inteligence_button_add;
            if (textBox == wisdom_textbox) return wisdom_button_add;
            if (textBox == charisma_textbox) return charisma_button_add;
            return null;
        }

        private Button GetRemoveButton(TextBox textBox)
        {
            if (textBox == strength_textbox) return strength_button_remove;
            if (textBox == dexterity_textbox) return dexterity_button_remove;
            if (textBox == constitution_textbox) return constitution_button_remove;
            if (textBox == inteligence_textbox) return inteligence_button_remove;
            if (textBox == wisdom_textbox) return wisdom_button_remove;
            if (textBox == charisma_textbox) return charisma_button_remove;
            return null;
        }

        private void RacesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RacesComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedRace = selectedItem.Content.ToString();
                AdjustAbilityScoresForRace();
            }
        }

        private void IncreaseAbilityScore(TextBox textBox)
        {
            int currentValue = int.Parse(textBox.Text);
            if (currentValue < 15)
            {
                textBox.Text = (currentValue + 1).ToString();
                UpdateButtonStates();
            }
        }

        private void AdjustAbilityScoresForRace()
        {
            strength_textbox.Text = "8";
            dexterity_textbox.Text = "8";
            constitution_textbox.Text = "8";
            inteligence_textbox.Text = "8";
            wisdom_textbox.Text = "8";
            charisma_textbox.Text = "8";
            switch (selectedRace.ToLower())
            {
                case "human":
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(dexterity_textbox);
                    IncreaseAbilityScore(constitution_textbox);
                    IncreaseAbilityScore(inteligence_textbox);
                    IncreaseAbilityScore(wisdom_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    break;

                case "elf":
                    IncreaseAbilityScore(dexterity_textbox);
                    IncreaseAbilityScore(dexterity_textbox);
                    IncreaseAbilityScore(inteligence_textbox);
                    break;

                case "dwarf":
                    IncreaseAbilityScore(constitution_textbox);
                    IncreaseAbilityScore(constitution_textbox);
                    IncreaseAbilityScore(wisdom_textbox);
                    break;

                case "halfling":
                    IncreaseAbilityScore(dexterity_textbox);
                    IncreaseAbilityScore(dexterity_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    break;

                case "dragonborn":
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    break;

                case "gnome":
                    IncreaseAbilityScore(inteligence_textbox);
                    IncreaseAbilityScore(inteligence_textbox);
                    IncreaseAbilityScore(constitution_textbox);
                    break;

                case "half-elf":
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(constitution_textbox);
                    break;

                case "half-orc":
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(strength_textbox);
                    IncreaseAbilityScore(constitution_textbox);
                    break;

                case "tiefling":
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(inteligence_textbox);
                    break;

                case "aasimar":
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(charisma_textbox);
                    IncreaseAbilityScore(wisdom_textbox);
                    break;

                default:
                    break;
            }

            UpdateButtonStates();
        }

        private TextBox GetAssociatedTextBox(Button button)
        {
            string buttonName = button.Name;
            string associatedTextBoxName = buttonName.Replace("_button_add", "_textbox").Replace("_button_remove", "_textbox");

            TextBox associatedTextBox = (TextBox)this.FindName(associatedTextBoxName);
            return associatedTextBox;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindow();
            strength_button_remove.IsEnabled = false;
            dexterity_button_remove.IsEnabled=false;
            constitution_button_remove.IsEnabled = false;
            inteligence_button_remove.IsEnabled = false;
            wisdom_button_remove.IsEnabled = false;
            charisma_button_remove.IsEnabled = false;
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = RacesComboBox.SelectedItem as ComboBoxItem;

            Character character = new();
            character.Name = characterName.Text;
            character.Race = cbi.Content.ToString();
            cbi = ClassesComboBox.SelectedItem as ComboBoxItem;
            character.Class = cbi.Content.ToString();
            cbi = SubclassesComboBox.SelectedItem as ComboBoxItem;
            character.SubClass = cbi.Content.ToString();
            if (spellcasting_ability.Text != "IDK")
                character.Spellcasting = spellcasting_ability.Text;
            else
                character.Spellcasting = "NaN";
            Stats stats = new()
            {
                strength = Convert.ToInt32(strength_textbox.Text),
                dexterity = Convert.ToInt32(dexterity_textbox.Text),
                constitution = Convert.ToInt32(constitution_textbox.Text),
                inteligence = Convert.ToInt32(inteligence_textbox.Text),
                wisdom = Convert.ToInt32(wisdom_textbox.Text),
                charisma = Convert.ToInt32(charisma_textbox.Text)
            };
            character.Stats = stats;
            window.frame.NavigationService.Navigate(new BackgroundCreator(window, character));
        }
    }
}
