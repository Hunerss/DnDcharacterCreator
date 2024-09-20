using DnDcharacterCreator.Classes;
using System.Windows;
using System.Windows.Controls;

namespace DnDcharacterCreator.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy SkillsCreator.xaml
    /// </summary>
    public partial class SkillsCreator : UserControl
    {
        MainWindow window;
        Character character;
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
        }

        private void SkillChecked(object sender, RoutedEventArgs e)
        {
            if (currentSelections < maxProficiencies)
            {
                currentSelections++;
                UpdateProficiencyCount();
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
            currentSelections--;
            UpdateProficiencyCount();
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

        public void SetCharacterClass(Character character)
        {
            AutoSelectSkills(character.Class);
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = AlignmentComboBox.SelectedItem as ComboBoxItem;

            character.Alignment = cbi.Content.ToString();
            cbi = BackgroundComboBox.SelectedItem as ComboBoxItem;
            character.Background = cbi.Content.ToString();
            character.Description = description.Text;
            character.PersonalityTraits = personality.Text;
            character.Ideals = ideals.Text;
            character.Bonds = bonds.Text;
            character.Flaws = flaws.Text;
            character.About = about.Text;
            window.frame.NavigationService.Navigate(new SkillsCreator(window, character));
        }
    }
}
