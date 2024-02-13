using SchoolBusDataAccess.Repositories.Abstract;
using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using SchoolBusProjectWPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string? _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public BaseRepository<Admin> AdminRepos { get; set; }

        public ICommand LoginCommand { get; set; }
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(LoginToAccount, IsLoginPossible);
            AdminRepos = new BaseRepository<Admin>();

        }

        public bool IsLoginPossible(object? param)
        {
            if (Username == null && Password == null) return false;
            return true;
        }


        public void LoginToAccount(object? param)
        {

            bool check = false;
            foreach (var a in AdminRepos.GetAll())
            {
                if (Username == a.UserName && Password == a.Password)
                {
                    check = true;
                    var adminLoginPageView = new AdminLoginPageView();
                    adminLoginPageView.DataContext = new AdminLoginPageViewModel();
                    var page = param as Page;
                    page?.NavigationService.Navigate(adminLoginPageView);
                    return;
                }
            }
                if (check==false)
                {
                    MessageBox.Show("Invalid username or password");
                }              
        }
    }
}
