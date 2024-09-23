using DnDcharacterCreator.UserControls;
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
using System.Windows.Shapes;

namespace DnDcharacterCreator
{
    /// <summary>
    /// Logika interakcji dla klasy ModifyProf.xaml
    /// </summary>
    public partial class ModifyProf : Window
    {
        Summary summary;
        string order;
        bool check;

        public ModifyProf(Summary s, string order, bool check)
        {
            InitializeComponent();
            summary = s;
            this.order = order;
            this.check = check;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi;
            string profName = name.Text.ToString(), profKind;
            if (check)
            {
                cbi = prof.SelectedItem as ComboBoxItem;
                profKind = cbi?.Content?.ToString();
                summary.GenerateNewProperities(profName, profKind, order, true);
            }
            else
            {
                profKind = "Item";
                summary.GenerateNewProperities(profName, profKind, order,false);
            }
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                item.Visibility = Visibility.Collapsed;
                prof.Visibility = Visibility.Visible;
                nameHeader.Text = "Proficiency Name";
            }
            else
            {
                item.Visibility = Visibility.Visible;
                prof.Visibility = Visibility.Collapsed;
                nameHeader.Text = "Item Name";
            }
        }
    }
}
