﻿using DnDcharacterCreator.Classes;
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
    /// Logika interakcji dla klasy BackgroundCreator.xaml
    /// </summary>
    public partial class BackgroundCreator : UserControl
    {
        MainWindow window;
        Character character;
        Random rnd = new();
        public BackgroundCreator(MainWindow win, Character character)
        {
            InitializeComponent();
            window = win;
            this.character = character;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AlignmentComboBox.SelectedIndex = rnd.Next(0, 9);
            BackgroundComboBox.SelectedIndex = rnd.Next(0, 12);
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