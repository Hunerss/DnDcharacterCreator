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
            name.IsReadOnly = false;
            race.IsReadOnly = false;
            clas.IsReadOnly = false;
            subclass.IsReadOnly = false;
            hitpoints.IsReadOnly = false;
            spellcastingAbility.IsReadOnly = false;
            spellcastingBonus.IsReadOnly = false;
            spellDC.IsReadOnly = false;
            strength.IsReadOnly = false;
            dexterity.IsReadOnly = false;
            constitution.IsReadOnly = false;
            intelligence.IsReadOnly = false;
            wisdom.IsReadOnly = false;
            charisma.IsReadOnly = false;
            strength_sv.IsReadOnly = false;
            dexterity_sv.IsReadOnly = false;
            constitution_sv.IsReadOnly = false;
            intelligence_sv.IsReadOnly = false;
            wisdom_sv.IsReadOnly = false;
            charisma_sv.IsReadOnly = false;
            strength_sv_prof.IsReadOnly = false;
            dexterity_sv_prof.IsReadOnly = false;
            constitution_sv_prof.IsReadOnly = false;
            intelligence_sv_prof.IsReadOnly = false;
            wisdom_sv_prof.IsReadOnly = false;
            charisma_sv_prof.IsReadOnly = false;
            alignment.IsReadOnly = false;
            background.IsReadOnly = false;
            description.IsReadOnly = false;
            ideals.IsReadOnly = false;
            bonds.IsReadOnly = false;
            flaws.IsReadOnly = false;
            about.IsReadOnly = false;

            acrobatics_score.IsReadOnly = false;
            acrobatics_prof.IsReadOnly = false;
            animal_handling_score.IsReadOnly = false;
            animal_handling_prof.IsReadOnly = false;
            arcana_score.IsReadOnly = false;
            arcana_prof.IsReadOnly = false;
            athletics_score.IsReadOnly = false;
            athletics_prof.IsReadOnly = false;
            deception_score.IsReadOnly = false;
            deception_prof.IsReadOnly = false;
            history_score.IsReadOnly = false;
            history_prof.IsReadOnly = false;
            insight_score.IsReadOnly = false;
            insight_prof.IsReadOnly = false;
            intimidation_score.IsReadOnly = false;
            intimidation_prof.IsReadOnly = false;
            investigation_score.IsReadOnly = false;
            investigation_prof.IsReadOnly = false;
            medicine_score.IsReadOnly = false;
            medicine_prof.IsReadOnly = false;
            nature_score.IsReadOnly = false;
            nature_prof.IsReadOnly = false;
            perception_score.IsReadOnly = false;
            perception_prof.IsReadOnly = false;
            performance_score.IsReadOnly = false;
            performance_prof.IsReadOnly = false;
            persuasion_score.IsReadOnly = false;
            persuasion_prof.IsReadOnly = false;
            religion_score.IsReadOnly = false;
            religion_prof.IsReadOnly = false;
            sleight_of_hand_score.IsReadOnly = false;
            sleight_of_hand_prof.IsReadOnly = false;
            stealth_score.IsReadOnly = false;
            stealth_prof.IsReadOnly = false;
            survival_score.IsReadOnly = false;
            survival_prof.IsReadOnly = false;

        }

        private void FrobidEditon_Click(object sender, RoutedEventArgs e)
        {
            name.IsReadOnly = true;
            race.IsReadOnly = true;
            clas.IsReadOnly = true;
            subclass.IsReadOnly = true;
            hitpoints.IsReadOnly = true;
            spellcastingAbility.IsReadOnly = true;
            spellcastingBonus.IsReadOnly = true;
            spellDC.IsReadOnly = true;
            strength.IsReadOnly = true;
            dexterity.IsReadOnly = true;
            constitution.IsReadOnly = true;
            intelligence.IsReadOnly = true;
            wisdom.IsReadOnly = true;
            charisma.IsReadOnly = true;
            strength_sv.IsReadOnly = true;
            dexterity_sv.IsReadOnly = true;
            constitution_sv.IsReadOnly = true;
            intelligence_sv.IsReadOnly = true;
            wisdom_sv.IsReadOnly = true;
            charisma_sv.IsReadOnly = true;
            strength_sv_prof.IsReadOnly = true;
            dexterity_sv_prof.IsReadOnly = true;
            constitution_sv_prof.IsReadOnly = true;
            intelligence_sv_prof.IsReadOnly = true;
            wisdom_sv_prof.IsReadOnly = true;
            charisma_sv_prof.IsReadOnly = true;
            alignment.IsReadOnly = true;
            background.IsReadOnly = true;
            description.IsReadOnly = true;
            ideals.IsReadOnly = true;
            bonds.IsReadOnly = true;
            flaws.IsReadOnly = true;
            about.IsReadOnly = true;

            acrobatics_score.IsReadOnly = true;
            acrobatics_prof.IsReadOnly = true;
            animal_handling_score.IsReadOnly = true;
            animal_handling_prof.IsReadOnly = true;
            arcana_score.IsReadOnly = true;
            arcana_prof.IsReadOnly = true;
            athletics_score.IsReadOnly = true;
            athletics_prof.IsReadOnly = true;
            deception_score.IsReadOnly = true;
            deception_prof.IsReadOnly = true;
            history_score.IsReadOnly = true;
            history_prof.IsReadOnly = true;
            insight_score.IsReadOnly = true;
            insight_prof.IsReadOnly = true;
            intimidation_score.IsReadOnly = true;
            intimidation_prof.IsReadOnly = true;
            investigation_score.IsReadOnly = true;
            investigation_prof.IsReadOnly = true;
            medicine_score.IsReadOnly = true;
            medicine_prof.IsReadOnly = true;
            nature_score.IsReadOnly = true;
            nature_prof.IsReadOnly = true;
            perception_score.IsReadOnly = true;
            perception_prof.IsReadOnly = true;
            performance_score.IsReadOnly = true;
            performance_prof.IsReadOnly = true;
            persuasion_score.IsReadOnly = true;
            persuasion_prof.IsReadOnly = true;
            religion_score.IsReadOnly = true;
            religion_prof.IsReadOnly = true;
            sleight_of_hand_score.IsReadOnly = true;
            sleight_of_hand_prof.IsReadOnly = true;
            stealth_score.IsReadOnly = true;
            stealth_prof.IsReadOnly = true;
            survival_score.IsReadOnly = true;
            survival_prof.IsReadOnly = true;
        }

        private void AddProf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveProf_Click(object sender, RoutedEventArgs e)
        {

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
                strength_sv_prof.Text = "PROF";
            }
            else
            {
                strength_sv.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                strength_sv_prof.Text = "";
            }

            if (character.SavingThrows.Dexterity)
            {
                dexterity_sv.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0) + character.Proficiency).ToString();
                dexterity_sv_prof.Text = "PROF";
            }
            else
            {
                dexterity_sv.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                dexterity_sv_prof.Text = "";
            }

            if (character.SavingThrows.Constitution)
            {
                constitution_sv.Text = (Math.Floor((character.Stats.Constitution - 10) / 2.0) + character.Proficiency).ToString();
                constitution_sv_prof.Text = "PROF";
            }
            else
            {
                constitution_sv.Text = (Math.Floor((character.Stats.Constitution - 10) / 2.0)).ToString();
                constitution_sv_prof.Text = "";
            }

            if (character.SavingThrows.Intelligence)
            {
                intelligence_sv.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0) + character.Proficiency).ToString();
                intelligence_sv_prof.Text = "PROF";
            }
            else
            {
                intelligence_sv.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                intelligence_sv_prof.Text = "";
            }

            if (character.SavingThrows.Wisdom)
            {
                wisdom_sv.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0) + character.Proficiency).ToString();
                wisdom_sv_prof.Text = "PROF";
            }
            else
            {
                wisdom_sv.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                wisdom_sv_prof.Text = "";
            }

            if (character.SavingThrows.Charisma)
            {
                charisma_sv.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0) + character.Proficiency).ToString();
                charisma_sv_prof.Text = "PROF";
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
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();;
                acrobatics_prof.Text = "PROF";
            }
            else
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();;
                acrobatics_prof.Text = "";
            }

            if (character.Skills.Contains("Acrobatics"))
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                acrobatics_prof.Text = "PROF";
            }
            else
            {
                acrobatics_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                acrobatics_prof.Text = "";
            }

            if (character.Skills.Contains("Animal Handling"))
            {
                animal_handling_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                animal_handling_prof.Text = "PROF";
            }
            else
            {
                animal_handling_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                animal_handling_prof.Text = "";
            }

            if (character.Skills.Contains("Arcana"))
            {
                arcana_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                arcana_prof.Text = "PROF";
            }
            else
            {
                arcana_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                arcana_prof.Text = "";
            }

            if (character.Skills.Contains("Athletics"))
            {
                athletics_score.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                athletics_prof.Text = "PROF";
            }
            else
            {
                athletics_score.Text = (Math.Floor((character.Stats.Strength - 10) / 2.0)).ToString();
                athletics_prof.Text = "";
            }

            if (character.Skills.Contains("Deception"))
            {
                deception_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                deception_prof.Text = "PROF";
            }
            else
            {
                deception_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                deception_prof.Text = "";
            }

            if (character.Skills.Contains("History"))
            {
                history_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                history_prof.Text = "PROF";
            }
            else
            {
                history_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                history_prof.Text = "";
            }

            if (character.Skills.Contains("Insight"))
            {
                insight_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                insight_prof.Text = "PROF";
            }
            else
            {
                insight_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                insight_prof.Text = "";
            }

            if (character.Skills.Contains("Intimidation"))
            {
                intimidation_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                intimidation_prof.Text = "PROF";
            }
            else
            {
                intimidation_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                intimidation_prof.Text = "";
            }

            if (character.Skills.Contains("Investigation"))
            {
                investigation_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                investigation_prof.Text = "PROF";
            }
            else
            {
                investigation_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                investigation_prof.Text = "";
            }

            if (character.Skills.Contains("Medicine"))
            {
                medicine_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                medicine_prof.Text = "PROF";
            }
            else
            {
                medicine_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                medicine_prof.Text = "";
            }

            if (character.Skills.Contains("Nature"))
            {
                nature_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                nature_prof.Text = "PROF";
            }
            else
            {
                nature_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                nature_prof.Text = "";
            }

            if (character.Skills.Contains("Perception"))
            {
                perception_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                perception_prof.Text = "PROF";
            }
            else
            {
                perception_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                perception_prof.Text = "";
            }

            if (character.Skills.Contains("Performance"))
            {
                performance_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                performance_prof.Text = "PROF";
            }
            else
            {
                performance_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                performance_prof.Text = "";
            }

            if (character.Skills.Contains("Persuasion"))
            {
                persuasion_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                persuasion_prof.Text = "PROF";
            }
            else
            {
                persuasion_score.Text = (Math.Floor((character.Stats.Charisma - 10) / 2.0)).ToString();
                persuasion_prof.Text = "";
            }

            if (character.Skills.Contains("Religion"))
            {
                religion_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                religion_prof.Text = "PROF";
            }
            else
            {
                religion_score.Text = (Math.Floor((character.Stats.Intelligence - 10) / 2.0)).ToString();
                religion_prof.Text = "";
            }

            if (character.Skills.Contains("Sleight of Hand"))
            {
                sleight_of_hand_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                sleight_of_hand_prof.Text = "PROF";
            }
            else
            {
                sleight_of_hand_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                sleight_of_hand_prof.Text = "";
            }

            if (character.Skills.Contains("Stealth"))
            {
                stealth_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                stealth_prof.Text = "PROF";
            }
            else
            {
                stealth_score.Text = (Math.Floor((character.Stats.Dexterity - 10) / 2.0)).ToString();
                stealth_prof.Text = "";
            }

            if (character.Skills.Contains("Survival"))
            {
                survival_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                survival_prof.Text = "PROF";
            }
            else
            {
                survival_score.Text = (Math.Floor((character.Stats.Wisdom - 10) / 2.0)).ToString();
                survival_prof.Text = "";
            }
            GenerateProficiences(profficiences_weapons, "Weapons");
            GenerateProficiences(profficiences_armor, "Armor");
            GenerateProficiences(profficiences_tools, "Tools");
            GenerateProficiences(profficiences_languages, "");
        }

        private void GenerateProficiences(StackPanel stackPanel, string kind)
        {
            stackPanel.Children.Clear();
            string[] profs;
            if (kind == "Weapons")
                profs = character.Proficiencies.Weapons;
            else if (kind == "Armors")
                profs = character.Proficiencies.Armor;
            else if (kind == "Tools")
                profs = character.Proficiencies.Tools;
            else
                profs = character.Proficiencies.Languages;
            for (int i = 0; i < profs.Length; i++)
            {
                TextBlock textBlock = new()
                {
                    Text = profs[i],
                };
                stackPanel.Children.Add(textBlock);
            }
        }
    }
}
