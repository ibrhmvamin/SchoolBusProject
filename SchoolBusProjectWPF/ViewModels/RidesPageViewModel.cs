
using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class RidesPageViewModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Ride> _rides { get; set; }
        public ObservableCollection<Ride> Rides { 
            get=>_rides;
            set
            {
                _rides = value;
                OnPropertyChanged();
            }            
        }

        private ObservableCollection<Student> _students { get; set; }
        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentRepository StudentRepository { get; set; }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        public ICommand? RemoveRideCommand { get; set; }      

        public BaseRepository<Ride> RideRepository { get; set; }

        public RidesPageViewModel()
        {
            RemoveRideCommand = new RelayCommand(RemoveRides);
            RideRepository = new BaseRepository<Ride>();
            Rides = new ObservableCollection<Ride>(RideRepository.GetAll()
            .Select(r => new Ride
            {
                 Id = r.Id,
                Name = r.Name,
                Car=r.Car
            }));
            StudentRepository = new StudentRepository();
            Students = new ObservableCollection<Student>(StudentRepository.GetAll());
        }

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

        private string? _carname;
        public string? carName
        {
            get { return _carname; }
            set
            {
                _carname = value;
                OnPropertyChanged();

            }
        }

        private string? _carNumber;
        public string? carNumber
        {
            get { return _carNumber; }
            set
            {
                _carNumber = value;
                OnPropertyChanged();

            }
        }

        private string? _maxSeats;
        public string? MaxSeats
        {
            get { return _maxSeats; }
            set
            {
                _maxSeats = value;
                OnPropertyChanged();

            }
        }

        private Ride _selectedRide;

        public Ride SelectedRide
        {
            get { return _selectedRide; }
            set { _selectedRide = value; OnPropertyChanged(); }
        }


        public void RemoveRides(object? param)
        {
            
        if (SelectedRide != null)
            {
                try
                {
                    RideRepository.Remove(SelectedRide);
                    RideRepository.SaveChanges();                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
