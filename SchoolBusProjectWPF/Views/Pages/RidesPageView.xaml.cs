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

namespace SchoolBusProjectWPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for RidesPageView.xaml
    /// </summary>
    public partial class RidesPageView : Page
    {
        public RidesPageView()
        {
            InitializeComponent();
        }

        private void BackToAdminPage(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
