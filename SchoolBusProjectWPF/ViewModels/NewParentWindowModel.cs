using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class NewParentWindowModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CreateParentCommand { get; set; }

        private string _firstname;
        public string Firstname
        { get { return _firstname; } set { _firstname = value; OnPropertyChanged(); } }

        private string _lastname;
        public string Lastname
        { get { return _lastname; } set { _lastname = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone
        { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        private string _userName;
        public string UserName
        { get { return _userName; } set { _userName = value; OnPropertyChanged(); } }

        private string _password;
        public string Password
        { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        public ParentRepository ParentRepository { get; set; }

        public NewParentWindowModel() 
        {
            CreateParentCommand = new RelayCommand(CreateParentInDatabase);
            ParentRepository= new ParentRepository();
        }

        public void CreateParentInDatabase(object? param)
        {
            try
            {
                var p = new Parent();
                p.Firstname = Firstname;
                p.Lastname = Lastname;
                p.Phone = Phone;
                p.UserName = UserName;
                p.Password = Password; 

                ParentRepository.Add(p);
                ParentRepository.SaveChanges();
                MessageBox.Show("Parent added to Database successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
