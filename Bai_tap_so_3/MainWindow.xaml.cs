﻿using System;
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

namespace Bai_tap_so_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] towers = { "Great Shevington", "Little Mudford", "Upper Gumtree", "Downley Hatch" };
        private string[] ringingMethods = { "Plain Bob", "Reverse Canterbury", "Grandsire", "Stedman", "Kent Treble Bob", "Old Oxford Delight", "Winchendon Place", "Norwich Surprise", "Crayford Little Court" };
        public MainWindow()
        {
            InitializeComponent();
            this.Reset();
        }
        public void Reset()
        {
            first_name.Text = String.Empty;
            last_name.Text = String.Empty;
            towernames.Items.Clear();
            foreach (string towername in towers)
            {
                towernames.Items.Add(towername);
            }
            towernames.Text = towernames.Items[0] as string;
            methods.Items.Clear();
            CheckBox method = null;
            foreach (string methodName in ringingMethods)
            {
                method = new CheckBox();
                method.Margin = new Thickness(0, 0, 0, 10);
                method.Content = methodName;
                methods.Items.Add(method);
            }
            isCaptain.IsChecked = false;
            novice.IsChecked = true;
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string nameAndTower = String.Format("Member name: {0} {1} from the tower at {2} rings the following methods:", first_name.Text, last_name.Text, towernames.Text);
            StringBuilder details = new StringBuilder();
            details.AppendLine(nameAndTower);
            foreach (CheckBox cb in methods.Items)
            {
                if (cb.IsChecked.Value)
                {
                    details.AppendLine(cb.Content.ToString());
                }
            }
            MessageBox.Show(details.ToString(), "Member Information");
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show
                                  ("Are you sure you want to quit",
                                    "Confirm",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question,
                                     MessageBoxResult.No);
            e.Cancel = (key == MessageBoxResult.No);
        } 
    }
}
