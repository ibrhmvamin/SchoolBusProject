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

namespace SchoolBusProjectWPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for NewClassWindow.xaml
    /// </summary>
    public partial class NewClassWindow : Window
    {
        public NewClassWindow()
        {
            InitializeComponent();
        }

        private void BackToAdminPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
