using DnDcharacterCreator.Classes;
using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace DnDcharacterCreator.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy SkillsCreator.xaml
    /// </summary>
    public partial class SkillsCreator : UserControl
    {
        MainWindow window;
        Character character;
        Character tmpCharacter;
        Random rnd = new();

        private int maxProficiencies = 3;
        private int currentSelections = 0;

        private Dictionary<string, string[]> classSkills = new Dictionary<string, string[]>
        {
            { "Barbarian", new[] { "Animal Handling", "Athletics", "Survival" } },
            { "Bard", new[] { "Deception", "Performance", "Persuasion" } },
            { "Cleric", new[] { "Insight", "Medicine", "Religion" } },
            { "Druid", new[] { "Animal Handling", "Arcana", "Nature" } },
            { "Fighter", new[] { "Acrobatics", "Athletics", "Perception" } },
            { "Monk", new[] { "Acrobatics", "History", "Stealth" } },
            { "Paladin", new[] { "Athletics", "Insight", "Religion" } },
            { "Rogue", new[] { "Acrobatics", "Deception", "Stealth" } },
            { "Sorcerer", new[] { "Arcana", "Deception", "Persuasion" } },
            { "Warlock", new[] { "Arcana", "Deception", "Intimidation" } },
            { "Wizard", new[] { "Arcana", "History", "Investigation" } }
        };

        public SkillsCreator(MainWindow win, Character character)
        {
            InitializeComponent();
            window = win;
            this.character = character;
            tmpCharacter = character;
        }

        private void SkillChecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Checked");
            if (currentSelections < maxProficiencies)
            {
                currentSelections++;
                UpdateProficiencyCount();
                if (currentSelections == 3)
                    BlockSkills();
            }
            else
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox != null)
                {
                    checkBox.IsChecked = false;
                    currentSelections--;
                }
            }
        }

        private void SkillUnchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Unchecked");
            currentSelections--;
            UpdateProficiencyCount();
            if (currentSelections < 3)
                UnblockAllSkills();
        }

        private void UpdateProficiencyCount()
        {
            ProficiencyCountTextBlock.Text = $"Choose your skills ({maxProficiencies - currentSelections} available)";
        }

        public void AutoSelectSkills(string characterClass)
        {
            if (classSkills.ContainsKey(characterClass))
            {
                var skillsFromClass = classSkills[characterClass];

                foreach (var skill in skillsFromClass)
                {
                    CheckBox checkBox = SkillsStackPanel.Children
                        .OfType<CheckBox>()
                        .FirstOrDefault(cb => cb.Content.ToString() == skill);

                    if (checkBox != null && !checkBox.IsChecked.HasValue)
                    {
                        checkBox.IsChecked = true;
                        currentSelections++;
                    }
                }
                UpdateProficiencyCount();
            }
        }

        public void AutoInsertLanguages()
        {
            switch (character.Race)
            {
                case "Human":
                    language_2.IsReadOnly = false;
                    break;
                case "Elf":
                    language_2.Text = "Elvish";
                    break;
                case "Dwarf":
                    language_2.Text = "Dwarvish";
                    break;
                case "Halfling":
                    language_2.Text = "Halfling";
                    break;
                case "Dragonborn":
                    language_2.Text = "Draconic";
                    break;
                case "Gnome":
                    language_2.Text = "Gnomish";
                    break;
                case "Half-Elf":
                    language_2.Text = "Elvish";
                    break;
                case "Half-Orc":
                    language_2.Text = "Orcish";
                    break;
                case "Tiefling":
                    language_2.Text = "Infernal";
                    break;
                case "Aasimar":
                    language_2.Text = "Celestial";
                    break;
                default:
                    break;
            }
        }

        public void ShowLanguages()
        {
            if (character.Race == "Half-Elf" && (character.Background == "Acolyte" || character.Background == "Sage"))
            {
                language_3.Visibility = Visibility.Visible;
                language_4.Visibility = Visibility.Visible;
                language_5.Visibility = Visibility.Visible;
            }
            else if (character.Background == "Acolyte" || character.Background == "Sage")
            {
                language_3.Visibility = Visibility.Visible;
                language_4.Visibility = Visibility.Visible;
            }
            else if (character.Race == "Half-Elf")
            {
                language_3.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AutoSelectSkills(character.Class);
            ShowLanguages();
            AutoInsertLanguages();
        }

        private void ResetItems(string category)
        {
            for (int i = 1; i <= 5; i++)
            {
                GetCheckBox(category, i).IsEnabled = true;
            }
        }

        private void ItemChecked(object sender, RoutedEventArgs e)
        {
            string name = ((CheckBox)sender).Name;
            string category = name[..^2];
            int index = int.Parse(name[^1..]);

            DisableAllItems(category);
            EnableItem(category, index);
        }

        private void ItemUnchecked(object sender, RoutedEventArgs e)
        {
            string name = ((CheckBox)sender).Name;
            string category = name[..^2];

            ResetItems(category);
        }

        private void DisableAllItems(string category)
        {
            for (int i = 1; i <= 5; i++)
            {
                GetCheckBox(category, i).IsEnabled = false;
            }
        }

        private void EnableItem(string category, int index)
        {
            GetCheckBox(category, index).IsEnabled = true;
        }

        private CheckBox GetCheckBox(string category, int index)
        {
            return category switch
            {
                "weapon" => (CheckBox)FindName($"weapon_{index}"),
                "armor" => (CheckBox)FindName($"armor_{index}"),
                "packs" => (CheckBox)FindName($"packs_{index}"),
                "tools" => (CheckBox)FindName($"tools_{index}"),
                _ => throw new ArgumentException("Unknown category")
            };
        }

        private void BlockSkills()
        {
            if(AcrobaticsCheckBox.IsChecked != true)
                AcrobaticsCheckBox.IsEnabled = false;
            if (AnimalHandlingCheckBox.IsChecked != true)
                AnimalHandlingCheckBox.IsEnabled = false;
            if (ArcanaCheckBox.IsChecked != true)
                ArcanaCheckBox.IsEnabled = false;
            if (AthleticsCheckBox.IsChecked != true)
                AthleticsCheckBox.IsEnabled = false;
            if (DeceptionCheckBox.IsChecked != true)
                DeceptionCheckBox.IsEnabled = false;
            if (HistoryCheckBox.IsChecked != true)
                HistoryCheckBox.IsEnabled = false;
            if (InsightCheckBox.IsChecked != true)
                InsightCheckBox.IsEnabled = false;
            if (IntimidationCheckBox.IsChecked != true)
                IntimidationCheckBox.IsEnabled = false;
            if (InvestigationCheckBox.IsChecked != true)
                InvestigationCheckBox.IsEnabled = false;
            if (MedicineCheckBox.IsChecked != true)
                MedicineCheckBox.IsEnabled = false;
            if (NatureCheckBox.IsChecked != true)
                NatureCheckBox.IsEnabled = false;
            if (PerceptionCheckBox.IsChecked != true)
                PerceptionCheckBox.IsEnabled = false;
            if (PerformanceCheckBox.IsChecked != true)
                PerformanceCheckBox.IsEnabled = false;
            if (PersuasionCheckBox.IsChecked != true)
                PersuasionCheckBox.IsEnabled = false;
            if (ReligionCheckBox.IsChecked != true)
                ReligionCheckBox.IsEnabled = false;
            if (SleightOfHandCheckBox.IsChecked != true)
                SleightOfHandCheckBox.IsEnabled = false;
            if (StealthCheckBox.IsChecked != true)
                StealthCheckBox.IsEnabled = false;
            if (SurvivalCheckBox.IsChecked != true)
                SurvivalCheckBox.IsEnabled = false;
        }

        private void UnblockAllSkills()
        {
            AcrobaticsCheckBox.IsEnabled = true;
            AnimalHandlingCheckBox.IsEnabled = true;
            ArcanaCheckBox.IsEnabled = true;
            AthleticsCheckBox.IsEnabled = true;
            DeceptionCheckBox.IsEnabled = true;
            HistoryCheckBox.IsEnabled = true;
            InsightCheckBox.IsEnabled = true;
            IntimidationCheckBox.IsEnabled = true;
            InvestigationCheckBox.IsEnabled = true;
            MedicineCheckBox.IsEnabled = true;
            NatureCheckBox.IsEnabled = true;
            PerceptionCheckBox.IsEnabled = true;
            PerformanceCheckBox.IsEnabled = true;
            PersuasionCheckBox.IsEnabled = true;
            ReligionCheckBox.IsEnabled = true;
            SleightOfHandCheckBox.IsEnabled = true;
            StealthCheckBox.IsEnabled = true;
            SurvivalCheckBox.IsEnabled = true;
        }

        private string[] GetSelectedSkillsAsArray(StackPanel stc)
        {
            List<string> selectedSkills = [];

            foreach (var child in stc.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                    selectedSkills.Add(checkBox.Content.ToString());
            }

            return selectedSkills.ToArray();
        }

        private List<string> GetSelectedSkillsAsList(StackPanel stc)
        {
            List<string> selectedSkills = [];

            foreach (var child in stc.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                    selectedSkills.Add(checkBox.Content.ToString());
            }

            return selectedSkills;
        }

        private Proficiencies GetProficiencies(string className)
        {
            Proficiencies proficiency = new();
            switch (className)
            {
                case "Barbarian":
                    proficiency.Weapons = new[] { "Greataxe", "Longsword" };
                    proficiency.Armor = new[] { "Light Armor", "Medium Armor" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Bard":
                    proficiency.Weapons = new[] { "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" };
                    proficiency.Armor = new[] { "Light Armor" };
                    proficiency.Tools = new[] { "Three Musical Instruments" };
                    break;

                case "Cleric":
                    proficiency.Weapons = new[] { "Simple Weapons", "Warhammer" };
                    proficiency.Armor = new[] { "Light Armor", "Medium Armor", "Shields" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Druid":
                    proficiency.Weapons = new[] { "Clubs", "Darts", "Javelins", "Quarterstaffs", "Scimitars" };
                    proficiency.Armor = new[] { "Light Armor", "Medium Armor", "Shields" };
                    proficiency.Tools = new[] { "Herbalism Kit" };
                    break;

                case "Fighter":
                    proficiency.Weapons = new[] { "Simple Weapons", "Martial Weapons" };
                    proficiency.Armor = new[] { "All Armor", "Shields" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Monk":
                    proficiency.Weapons = new[] { "Simple Weapons", "Shortswords" };
                    proficiency.Armor = new[] { "None" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Paladin":
                    proficiency.Weapons = new[] { "Simple Weapons", "Martial Weapons" };
                    proficiency.Armor = new[] { "All Armor", "Shields" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Rogue":
                    proficiency.Weapons = new[] { "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" };
                    proficiency.Armor = new[] { "Light Armor" };
                    proficiency.Tools = new[] { "Thieves' Tools" };
                    break;

                case "Sorcerer":
                    proficiency.Weapons = new[] { "Simple Weapons" };
                    proficiency.Armor = new[] { "Light Armor" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Warlock":
                    proficiency.Weapons = new[] { "Simple Weapons" };
                    proficiency.Armor = new[] { "Light Armor" };
                    proficiency.Tools = new[] { "None" };
                    break;

                case "Wizard":
                    proficiency.Weapons = new[] { "Daggers", "Darts", "Quarterstaffs", "Slings" };
                    proficiency.Armor = new[] { "None" };
                    proficiency.Tools = new[] { "None" };
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
            return proficiency;
        }

        private string[] GetLangauges()
        {
            List<string> list = new();
            if(language_1.Text!="")
                list.Add(language_1.Text);
            if (language_2.Text != "")
                list.Add(language_2.Text);
            if (language_3.Text != "")
                list.Add(language_3.Text);
            if (language_4.Text != "")
                list.Add(language_4.Text);
            if (language_5.Text != "")
                list.Add(language_5.Text);
            return list.ToArray();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            character.Skills = GetSelectedSkillsAsArray(SkillsStackPanel);
            Inventory inventory = new()
            {
                Gold = 50,
                Items = GetSelectedSkillsAsList(ItemsStackPanel)
            };
            character.Inventory = inventory;
            character.Proficiencies = GetProficiencies(character.Class);
            character.Proficiencies.Languages = GetLangauges();

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "DnDCharacterCreator");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            SaveFileDialog saveFileDialog1 = new()
            {
                Filter = "XML File|*.xml",
                Title = "Save to File",
                InitialDirectory = folderPath
            };

            if (saveFileDialog1.ShowDialog() == true)
            {
                try
                {
                    XmlSerializer serializer = new(typeof(Character));
                    using StreamWriter writer = new(saveFileDialog1.FileName);
                    serializer.Serialize(writer, character);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}");
                }
            }
            window.frame.NavigationService.Navigate(new Summary(window, character));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.Navigate(new BackgroundCreator(window, tmpCharacter));
        }
    }
}
