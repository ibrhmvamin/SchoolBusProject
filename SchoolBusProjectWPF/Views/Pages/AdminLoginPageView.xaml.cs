using SchoolBusProjectWPF.ViewModels;
using System.Windows.Controls;

namespace SchoolBusProjectWPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for AdminLoginPageView.xaml
    /// </summary>
    public partial class AdminLoginPageView : Page
    {
        public AdminLoginPageView()
        {
            DataContext=new AdminLoginPageViewModel();
            InitializeComponent();
        }
    }
}
