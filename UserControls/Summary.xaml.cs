using DnDcharacterCreator.Classes;
using System.Windows;
using System.Windows.Controls;

namespace DnDcharacterCreator.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Summary.xaml
    /// </summary>
    public partial class Summary : UserControl
    {
        MainWindow window;
        Character character;
        public Summary(MainWindow win, Character character)
        {
            InitializeComponent();
            window = win;
            this.character = character;
        }

        private void AllowEditon_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = [name, race, clas, subclass, hitpoints, spellcastingAbility, spellcastingBonus, spellDC, strength, dexterity, constitution,
                intelligence, wisdom, charisma, strength_sv, dexterity_sv, constitution_sv, intelligence_sv, wisdom_sv, charisma_sv, strength_sv_prof, dexterity_sv_prof,
                constitution_sv_prof, intelligence_sv_prof, wisdom_sv_prof, charisma_sv_prof, alignment, background, description, ideals, bonds, flaws, about,
                acrobatics_score, acrobatics_prof, animal_handling_score, animal_handling_prof, arcana_score, arcana_prof, athletics_score, athletics_prof, deception_score,
                deception_prof, history_score, history_prof, insight_score, insight_prof, intimidation_score, intimidation_prof, investigation_score, investigation_prof,
                medicine_score, medicine_prof, nature_score, nature_prof, perception_score, perception_prof, performance_score, performance_prof, persuasion_score,
                persuasion_prof, religion_score, religion_prof, sleight_of_hand_score, sleight_of_hand_prof, stealth_score, stealth_prof, survival_score, survival_prof, gold];
            foreach (TextBox textBox in textBoxes)
                textBox.IsReadOnly = false;
        }

        private void FrobidEditon_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = [name, race, clas, subclass, hitpoints, spellcastingAbility, spellcastingBonus, spellDC, strength, dexterity, constitution,
                intelligence, wisdom, charisma, strength_sv, dexterity_sv, constitution_sv, intelligence_sv, wisdom_sv, charisma_sv, strength_sv_prof, dexterity_sv_prof,
                constitution_sv_prof, intelligence_sv_prof, wisdom_sv_prof, charisma_sv_prof, alignment, background, description, ideals, bonds, flaws, about,
                acrobatics_score, acrobatics_prof, animal_handling_score, animal_handling_prof, arcana_score, arcana_prof, athletics_score, athletics_prof, deception_score,
                deception_prof, history_score, history_prof, insight_score, insight_prof, intimidation_score, intimidation_prof, investigation_score, investigation_prof,
                medicine_score, medicine_prof, nature_score, nature_prof, perception_score, perception_prof, performance_score, performance_prof, persuasion_score,
                persuasion_prof, religion_score, religion_prof, sleight_of_hand_score, sleight_of_hand_prof, stealth_score, stealth_prof, survival_score, survival_prof, gold];
            foreach (TextBox textBox in textBoxes)
                textBox.IsReadOnly = true;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ModifyProf modifyProf = new(this, "Add", false);
            modifyProf.Show();
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            ModifyProf modifyProf = new(this, "Remove", false);
            modifyProf.Show();
        }

        private void AddProf_Click(object sender, RoutedEventArgs e)
        {
            ModifyProf modifyProf = new(this, "Add", true);
            modifyProf.Show();
        }
        private void RemoveProf_Click(object sender, RoutedEventArgs e)
        {
            ModifyProf modifyProf = new(this, "Remove", true);
            modifyProf.Show();
        }

        public void GenerateNewProperities(string properityName, string properityKind, string order, bool check)
        {
            List<string> list = properityKind switch
            {
                "Weapons" => new List<string>(character.Proficiencies.Weapons),
                "Armors" => new List<string>(character.Proficiencies.Armor),
                "Tools" => new List<string>(character.Proficiencies.Tools),
                "Languages" => new List<string>(character.Proficiencies.Languages),
                "Inventory" => new List<string>(character.Inventory.Items),
                _ => null
            };

            if (list == null)
            {
                if (check)
                    MessageBox.Show("No proficiency with that name exists in this category.");
                else
                    MessageBox.Show("No item with that name exists.");
                return;
            }


            if (order == "Add")
            {
                list.Add(properityName);
                Console.WriteLine("Item/Prof added");
            }
            else if (order == "Remove")
            {
                list.Remove(properityName);
                Console.WriteLine("Item/Prof removed");
            }
            else
            {
                Console.WriteLine("Invalid order");
                return;
            }

            list.Sort();

            switch (properityKind)
            {
                case "Weapons":
                    character.Proficiencies.Weapons = list.ToArray();
                    break;
                case "Armors":
                    character.Proficiencies.Armor = list.ToArray();
                    break;
                case "Tools":
                    character.Proficiencies.Tools = list.ToArray();
                    break;
                case "Languages":
                    character.Proficiencies.Languages = list.ToArray();
                    break;
                case "Inventory":
                    character.Inventory.Items = list;
                    break;
            }

            GeneratePanels(profficiences_weapons, "Weapons");
            GeneratePanels(profficiences_armor, "Armors");
            GeneratePanels(profficiences_tools, "Tools");
            GeneratePanels(profficiences_languages, "");
            GeneratePanels(items, "Inventory");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetData();
        }

        private void SetData()
        {
            name.Text = character.Name;
            race.Text = character.Race;
            clas.Text = character.Class;
            subclass.Text = character.SubClass;
            hitpoints.Text = character.HitPoints.ToString();
            proficiency.Text = character.Proficiency.ToString();
            if (character.Spellcasting == "NaN")
                spellcastingContainer.Visibility = Visibility.Collapsed;
            else
            {
                spellcastingContainer.Visibility = Visibility.Visible;
                spellcastingAbility.Text = character.Spellcasting;
                int spellcastingModifier;
                if (character.Spellcasting == "Charisma")
                    spellcastingModifier = character.Stats.Charisma;
                else if (character.Spellcasting == "Wisdom")
                    spellcastingModifier = character.Stats.Wisdom;
                else if (character.Spellcasting == "Intelligence")
                    spellcastingModifier = character.Stats.Intelligence;
                else
                {
                    spellcastingModifier = 0;
                    Console.WriteLine("Error");
                }
                spellcastingBonus.Text = (8 + character.Proficiency + spellcastingModifier).ToString();
                spellDC.Text = (character.Proficiency + spellcastingModifier).ToString();
            }
            strength.Text = character.Stats.Strength.ToString();
            dexterity.Text = character.Stats.Dexterity.ToString();
            constitution.Text = character.Stats.Constitution.ToString();
            intelligence.Text = character.Stats.Intelligence.ToString();
            wisdom.Text = character.Stats.Wisdom.ToString();
            charisma.Text = character.Stats.Charisma.ToString();

            if (character.SavingThrows.Strength)
            {
                strength_sv.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0) + character.Proficiency).ToString();
                strength_sv_prof.Text = "PR";
            }
            else
            {
                strength_sv.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                strength_sv_prof.Text = "";
            }

            if (character.SavingThrows.Dexterity)
            {
                dexterity_sv.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0) + character.Proficiency).ToString();
                dexterity_sv_prof.Text = "PR";
            }
            else
            {
                dexterity_sv.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                dexterity_sv_prof.Text = "";
            }

            if (character.SavingThrows.Constitution)
            {
                constitution_sv.Text = (Math.Floor((character.Stats.Constitution - 10) / 2.0) + character.Proficiency).ToString();
                constitution_sv_prof.Text = "PR";
            }
            else
            {
                constitution_sv.Text = (Math.Floor((character.Stats.Constitution - 10) / 2.0)).ToString();
                constitution_sv_prof.Text = "";
            }

            if (character.SavingThrows.Intelligence)
            {
                intelligence_sv.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0) + character.Proficiency).ToString();
                intelligence_sv_prof.Text = "PR";
            }
            else
            {
                intelligence_sv.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                intelligence_sv_prof.Text = "";
            }

            if (character.SavingThrows.Wisdom)
            {
                wisdom_sv.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0) + character.Proficiency).ToString();
                wisdom_sv_prof.Text = "PR";
            }
            else
            {
                wisdom_sv.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                wisdom_sv_prof.Text = "";
            }

            if (character.SavingThrows.Charisma)
            {
                charisma_sv.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0) + character.Proficiency).ToString();
                charisma_sv_prof.Text = "PR";
            }
            else
            {
                charisma_sv.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                charisma_sv_prof.Text = "";
            }



            alignment.Text = character.Alignment;
            background.Text = character.Background;
            description.Text = character.Description;
            ideals.Text = character.Ideals;
            bonds.Text = character.Bonds;
            flaws.Text = character.Flaws;
            about.Text = character.About;


            if (character.Skills.Contains("Acrobatics"))
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString(); ;
                acrobatics_prof.Text = "PR";
            }
            else
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString(); ;
                acrobatics_prof.Text = "";
            }

            if (character.Skills.Contains("Acrobatics"))
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                acrobatics_prof.Text = "PR";
            }
            else
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                acrobatics_prof.Text = "";
            }

            if (character.Skills.Contains("Animal Handling"))
            {
                animal_handling_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                animal_handling_prof.Text = "PR";
            }
            else
            {
                animal_handling_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                animal_handling_prof.Text = "";
            }

            if (character.Skills.Contains("Arcana"))
            {
                arcana_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                arcana_prof.Text = "PR";
            }
            else
            {
                arcana_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                arcana_prof.Text = "";
            }

            if (character.Skills.Contains("Athletics"))
            {
                athletics_score.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                athletics_prof.Text = "PR";
            }
            else
            {
                athletics_score.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                athletics_prof.Text = "";
            }

            if (character.Skills.Contains("Deception"))
            {
                deception_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                deception_prof.Text = "PR";
            }
            else
            {
                deception_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                deception_prof.Text = "";
            }

            if (character.Skills.Contains("History"))
            {
                history_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                history_prof.Text = "PR";
            }
            else
            {
                history_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                history_prof.Text = "";
            }

            if (character.Skills.Contains("Insight"))
            {
                insight_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                insight_prof.Text = "PR";
            }
            else
            {
                insight_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                insight_prof.Text = "";
            }

            if (character.Skills.Contains("Intimidation"))
            {
                intimidation_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                intimidation_prof.Text = "PR";
            }
            else
            {
                intimidation_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                intimidation_prof.Text = "";
            }

            if (character.Skills.Contains("Investigation"))
            {
                investigation_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                investigation_prof.Text = "PR";
            }
            else
            {
                investigation_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                investigation_prof.Text = "";
            }

            if (character.Skills.Contains("Medicine"))
            {
                medicine_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                medicine_prof.Text = "PR";
            }
            else
            {
                medicine_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                medicine_prof.Text = "";
            }

            if (character.Skills.Contains("Nature"))
            {
                nature_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                nature_prof.Text = "PR";
            }
            else
            {
                nature_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                nature_prof.Text = "";
            }

            if (character.Skills.Contains("Perception"))
            {
                perception_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                perception_prof.Text = "PR";
            }
            else
            {
                perception_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                perception_prof.Text = "";
            }

            if (character.Skills.Contains("Performance"))
            {
                performance_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                performance_prof.Text = "PR";
            }
            else
            {
                performance_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                performance_prof.Text = "";
            }

            if (character.Skills.Contains("Persuasion"))
            {
                persuasion_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                persuasion_prof.Text = "PR";
            }
            else
            {
                persuasion_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                persuasion_prof.Text = "";
            }

            if (character.Skills.Contains("Religion"))
            {
                religion_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                religion_prof.Text = "PR";
            }
            else
            {
                religion_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                religion_prof.Text = "";
            }

            if (character.Skills.Contains("Sleight of Hand"))
            {
                sleight_of_hand_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                sleight_of_hand_prof.Text = "PR";
            }
            else
            {
                sleight_of_hand_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                sleight_of_hand_prof.Text = "";
            }

            if (character.Skills.Contains("Stealth"))
            {
                stealth_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                stealth_prof.Text = "PR";
            }
            else
            {
                stealth_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                stealth_prof.Text = "";
            }

            if (character.Skills.Contains("Survival"))
            {
                survival_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                survival_prof.Text = "PR";
            }
            else
            {
                survival_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                survival_prof.Text = "";
            }
            gold.Text = character.Inventory.Gold.ToString();
            GeneratePanels(profficiences_weapons, "Weapons");
            GeneratePanels(profficiences_armor, "Armors");
            GeneratePanels(profficiences_tools, "Tools");
            GeneratePanels(profficiences_languages, "");
            GeneratePanels(items, "Inventory");
            Console.WriteLine(character.Inventory.Items.Count);
        }

        private void GeneratePanels(StackPanel stackPanel, string kind)
        {
            stackPanel.Children.Clear();
            string[] profs;
            if (kind == "Weapons")
                profs = character.Proficiencies.Weapons;
            else if (kind == "Armors")
                profs = character.Proficiencies.Armor;
            else if (kind == "Tools")
                profs = character.Proficiencies.Tools;
            else if (kind == "Inventory")
                profs = [.. character.Inventory.Items];
            else
                profs = character.Proficiencies.Languages;

            if (profs.Length > 0)
            {
                for (int i = 0; i < profs.Length; i++)
                {
                    TextBlock textBlock = new()
                    {
                        Text = profs[i],
                    };
                    stackPanel.Children.Add(textBlock);
                }
            }
            else
            {
                TextBlock textBlock = new()
                {
                    Text = "None",
                };
                stackPanel.Children.Add(textBlock);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.Navigate(new MainMenu(window));
        }
    }
}
