using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using SchoolBusProjectWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class CarPageViewModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();

            }
        }
        private Car _selectedCar;

        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; OnPropertyChanged(); }
        }

        private string? _number;
        public string? Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();

            }
        }

        private string? _seatCount;
        public string? SeatCount
        {
            get { return _seatCount; }
            set
            {
                _seatCount = value;
                OnPropertyChanged();

            }
        }

        public BaseRepository<Ride> RideRepos { get; set; }
        
        public CarRepository CarRepository { get; set; }
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set { _cars = value; OnPropertyChanged(); }
        }
        public ICommand AddCarCommand { get; set; }
        public ICommand EditCarCommand { get; set; }
        public ICommand RemoveCarCommand { get; set; }

        public CarPageViewModel()
        {
            CarRepository = new CarRepository();
            Cars= new ObservableCollection<Car>(CarRepository.GetAll());
            AddCarCommand = new RelayCommand(ToCreateCarWindow);
            EditCarCommand = new RelayCommand(EditCar);
            RemoveCarCommand = new RelayCommand(RemoveCar);
        }
        public void RemoveCar(object? param)
        {
            try
            {
                CarRepository.Remove(SelectedCar);
                CarRepository.SaveChanges();
                MessageBox.Show("Car deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditCar(object? param)
        {
            try
            {
                if (SelectedCar != null)
                {
                    CarRepository.Update(SelectedCar);
                    CarRepository.SaveChanges();
                    MessageBox.Show("Car edited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ToCreateCarWindow(object? param)
        {
            var mcw = new NewCarWindow();
            mcw.DataContext=new NewCarWindowModel();
            mcw.Show();
        }
    }
}
