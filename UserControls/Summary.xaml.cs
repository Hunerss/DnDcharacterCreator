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

        private void allowEditon_Click(object sender, RoutedEventArgs e)
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
        }

        private void frobidEditon_Click(object sender, RoutedEventArgs e)
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
        }

        private void addProf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void removeProf_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
