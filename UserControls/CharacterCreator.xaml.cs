using DnDcharacterCreator.Classes;
using System.Diagnostics;
using System.Security.Claims;
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
            int race = rnd.Next(0, 10);
            RacesComboBox.SelectedIndex = race;
            ClassesComboBox.SelectedIndex = rnd.Next(0,10);
            SubclassesComboBox.SelectedIndex = rnd.Next(0,5);
            characterName.Text = GenerateRandomName(race);
        }

        private void ClassesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedClass = (ClassesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            ShowSpellcastingAbilityForClass(selectedClass);
            switch (selectedClass)
            {
                case "Barbarian":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Berserker" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Totem Warrior" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Ancestral Guardian" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Storm Herald" });
                    break;
                case "Bard":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "College of Lore" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "College of Valor" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "College of Glamour" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "College of Whispers" });
                    break;
                case "Cleric":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Life Domain" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "War Domain" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Trickery Domain" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Knowledge Domain" });
                    break;
                case "Druid":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Circle of the Moon" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Circle of the Land" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Circle of Spores" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Circle of Stars" });
                    break;
                case "Fighter":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Champion" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Battle Master" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Eldritch Knight" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Arcane Archer" });
                    break;
                case "Monk":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Way of the Open Hand" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Way of Shadow" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Way of the Four Elements" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Way of the Drunken Master" });
                    break;
                case "Paladin":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Oath of Devotion" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Oath of Vengeance" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Oath of the Ancients" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Oath of Conquest" });
                    break;
                case "Ranger":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Hunter" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Beast Master" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Gloom Stalker" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Horizon Walker" });
                    break;
                case "Rogue":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Thief" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Assassin" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Arcane Trickster" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Swashbuckler" });
                    break;
                case "Sorcerer":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Draconic Bloodline" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Wild Magic" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Storm Sorcery" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "Divine Soul" });
                    break;
                case "Warlock":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "The Fiend" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "The Great Old One" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "The Hexblade" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "The Genie" });
                    break;
                case "Wizard":
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "School of Evocation" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "School of Illusion" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "School of Necromancy" });
                    SubclassesComboBox.Items.Add(new ComboBoxItem { Content = "School of Transmutation" });
                    break;
            }

            SubclassesComboBox.SelectedIndex = 0;
        }

        private void ShowSpellcastingAbilityForClass(string selectedClass)
        {
            string[] spellcastingClasses = { "Bard", "Cleric", "Druid", "Sorcerer", "Warlock", "Wizard", "Paladin", "Monk" };

            if (Array.Exists(spellcastingClasses, element => element == selectedClass))
            {
                spellcasting_ability_text.Visibility = Visibility.Visible;
                spellcasting_ability.Visibility = Visibility.Visible;

                spellcasting_ability.Text = selectedClass switch
                {
                    "Bard" => "Charisma",
                    "Sorcerer" => "Charisma",
                    "Warlock" => "Charisma",
                    "Paladin" => "Charisma",
                    "Cleric" => "Wisdom",
                    "Druid" => "Wisdom",
                    "Monk" => "Wisdom",
                    "Wizard" => "Intelligence",
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[,] hitpoints = new int[,]
            {
                { 7, 12 }, // Barbarian
                { 5, 8 },  // Bard
                { 5, 8 },  // Cleric
                { 5, 8 },  // Druid
                { 6, 10 }, // Fighter
                { 5, 8 },  // Monk
                { 6, 10 }, // Paladin
                { 5, 8 },  // Rogue
                { 4, 6 },  // Sorcerer
                { 5, 8 },  // Warlock
                { 4, 6 }   // Wizard
            };
            ComboBoxItem comboBoxItem = ClassesComboBox.SelectedItem as ComboBoxItem;
            string selectedClass = comboBoxItem.Content.ToString();
            int v = selectedClass switch
            {
                "Barbarian" => 0,
                "Bard" => 1,
                "Cleric" => 2,
                "Druid" => 3,
                "Fighter" => 4,
                "Monk" => 5,
                "Paladin" => 6,
                "Rogue" => 7,
                "Sorcerer" => 8,
                "Warlock" => 9,
                "Wizard" => 10,
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

        private void Ability_scores_DropDownClosed(object sender, EventArgs e)
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

        private void Add_Click(object sender, RoutedEventArgs e)
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

        private void Remove_Click(object sender, RoutedEventArgs e)
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

        private SavingThrows GetSavingThrows(string className)
        {
            SavingThrows sv = new();
            switch (className)
            {
                case "Barbarian":
                    sv.Strength = true;       
                    sv.Dexterity = false;
                    sv.Constitution = true;   
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = false;
                    break;

                case "Bard":
                    sv.Strength = false;
                    sv.Dexterity = true;    
                    sv.Constitution = false;
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = true;     
                    break;

                case "Cleric":
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = true; 
                    sv.Intelligence = false;
                    sv.Wisdom = true;         
                    sv.Charisma = false;
                    break;

                case "Druid":
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = true;   
                    sv.Intelligence = false;
                    sv.Wisdom = true;         
                    sv.Charisma = false;
                    break;

                case "Fighter":
                    sv.Strength = true;      
                    sv.Dexterity = false;
                    sv.Constitution = true;    
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = false;
                    break;

                case "Monk":
                    sv.Strength = false;
                    sv.Dexterity = true;       
                    sv.Constitution = false;
                    sv.Intelligence = false;
                    sv.Wisdom = true;           
                    sv.Charisma = false;
                    break;

                case "Paladin":
                    sv.Strength = true;       
                    sv.Dexterity = false;
                    sv.Constitution = true;     
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = true;       
                    break;

                case "Rogue":
                    sv.Strength = false;
                    sv.Dexterity = true;       
                    sv.Constitution = false;
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = false;
                    break;

                case "Sorcerer":
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = true;    
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = true;      
                    break;

                case "Warlock":
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = true;     
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = true;        
                    break;

                case "Wizard":
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = false;
                    sv.Intelligence = true;      
                    sv.Wisdom = false;
                    sv.Charisma = false;
                    break;

                default:
                    sv.Strength = false;
                    sv.Dexterity = false;
                    sv.Constitution = false;
                    sv.Intelligence = false;
                    sv.Wisdom = false;
                    sv.Charisma = false;
                    break;
            }
            return sv;
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = RacesComboBox.SelectedItem as ComboBoxItem;

            Character character = new()
            {
                Name = characterName.Text,
                Race = cbi?.Content?.ToString()
            };
            cbi = ClassesComboBox.SelectedItem as ComboBoxItem;
            character.Class = cbi?.Content?.ToString();

            cbi = SubclassesComboBox.SelectedItem as ComboBoxItem;
            character.SubClass = cbi?.Content?.ToString();

            character.Spellcasting = spellcasting_ability.Text != "IDK" ? spellcasting_ability.Text : "NaN";

            Stats stats = new()
            {
                Strength = Convert.ToInt32(strength_textbox.Text),
                Dexterity = Convert.ToInt32(dexterity_textbox.Text),
                Constitution = Convert.ToInt32(constitution_textbox.Text),
                Intelligence = Convert.ToInt32(inteligence_textbox.Text),
                Wisdom = Convert.ToInt32(wisdom_textbox.Text),
                Charisma = Convert.ToInt32(charisma_textbox.Text)
            };
            character.Stats = stats;
            character.SavingThrows = GetSavingThrows(character.Class);
            character.HitPoints = Convert.ToInt32(hitpoints_textbox.Text)+ character.Stats.Constitution;
            character.Proficiency = 3;
            window.frame.NavigationService.Navigate(new BackgroundCreator(window, character));
        }
    }
}
