using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class NewDriverWindowModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CreateDriverCommand { get; set; }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        private string _userName;
        public string UserName
        { get { return _userName; } set { _userName = value; OnPropertyChanged(); } }

        private string _password;
        public string Password
        { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private string _address;
        public string Address
        { get { return _address; } set { _address = value; OnPropertyChanged(); } }

        private string _licence;
        public string Licence
        { get { return _licence; } set { _licence = value; OnPropertyChanged(); } }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        { get { return _cars; } set { _cars = value; OnPropertyChanged(); } }

        private ObservableCollection<Driver> _drivers;
        public ObservableCollection<Driver> Drivers
        { get { return _drivers; } set { _drivers = value; OnPropertyChanged(); } }

        private Car _car;
        public Car Car
        { get { return _car; } set { _car = value; OnPropertyChanged(); } }
        public CarRepository CarRepository { get; set; }

        public NewDriverWindowModel()
        {
            CreateDriverCommand = new RelayCommand(CreateNewDriverInDatabase);
            Drivers = new ObservableCollection<Driver>();
            Cars = new ObservableCollection<Car>(CarRepository.GetAll());
        }


        private void CreateNewDriverInDatabase(object? obj)
        {

        }
    }
}
