using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using SchoolBusProjectWPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class AdminLoginPageViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students { 
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Car> _cars;

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<S_Class> _s_class;

        public ObservableCollection<S_Class> S_Class
        {
            get => _s_class;
            set
            {
                _s_class = value;
                OnPropertyChanged();
            }
        }
        public ParentRepository ParentRepository { get; set; }

        private ObservableCollection<Parent> _parent;

        public ObservableCollection<Parent> Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Ride> _rides;

        public ObservableCollection<Ride> Rides
        {
            get => _rides;
            set
            {
                _rides = value;
                OnPropertyChanged();
            }
        }
        public StudentRepository StudentRepository { get;set; }
        private ObservableCollection<Student> _selectedStudents;
        public ObservableCollection<Student> SelectedStudents
        {
            get { return _selectedStudents; }
            set
            {
                _selectedStudents = value;
                OnPropertyChanged(nameof(SelectedStudents));
            }
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

        


        private ObservableCollection<Car> _car;
        public ObservableCollection<Car> Car
        {
            get { return _car; }
            set
            {
                _car = value;
                OnPropertyChanged();                
            }
        }

        private ObservableCollection<Driver> _driver;
        public ObservableCollection<Driver> Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                OnPropertyChanged();
            }
        }

        private int? _maxSeatCount;
        public int? MaxSeatCount
        {
            get { return _maxSeatCount; }
            set
            {
                _maxSeatCount = value;
                OnPropertyChanged();
            }
        }      

        private int? _rideId;
        public int? RideId
        {
            get { return _rideId; }
            set
            {
                _rideId = value;
                OnPropertyChanged();
            }
        }
        public BaseRepository<Ride> RideRepository { get; set; }

        public ICommand RidesCommand { get; set; }
        public ICommand ClassCommand { get; set; }
        public ICommand StudentCommand { get; set; }
        public ICommand DriverCommand { get; set; }
        public ICommand ParentCommand { get; set; }
        public ICommand CarCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }


        public AdminLoginPageViewModel()
        {
            RidesCommand = new RelayCommand(ToRidesPage);
            ClassCommand = new RelayCommand(ToClassPage);
            StudentCommand = new RelayCommand(ToStudentPage);
            DriverCommand = new RelayCommand(ToDriverPage);
            ParentCommand = new RelayCommand(ToParentPage);
            CarCommand = new RelayCommand(ToCarPage);
            StudentRepository=new StudentRepository();
            Students = new ObservableCollection<Student>(StudentRepository.GetAll());
            RideRepository = new BaseRepository<Ride>();
            ParentRepository = new ParentRepository();
            Parent = new ObservableCollection<Parent>(ParentRepository.GetAll());
            AddStudentCommand = new RelayCommand(AddStudentsToRide);
            RemoveStudentCommand = new RelayCommand(RemmoveStudentsToRide);

        }

        private void RemmoveStudentsToRide(object? obj)
        {
            ///////////////
        }

        private void AddStudentsToRide(object? obj)
        {
            ////////////////////    
        }

        public void ToCarPage(object? param)
        {
            var cp = new CarPageView();
            cp.DataContext = new CarPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(cp);
        }

        public void ToParentPage(object? param)
        {
            var pp = new ParentPageView();
            pp.DataContext = new ParentPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(pp);
        }

        public void ToDriverPage(object? param)
        {
            var dp = new DriverPageView();
            dp.DataContext = new DriverPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(dp);
        }

        public void ToStudentPage(object? param)
        {
            var sp = new StudentPageView();
            sp.DataContext = new StudentPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(sp);
        }

        public void ToRidesPage(object? param)
        {
            var rp = new RidesPageView();
            rp.DataContext = new RidesPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(rp);
        }
        public void ToClassPage(object? param)
        {
            var cp = new ClassPageView();
            cp.DataContext = new ClassPageViewModel();
            var p = param as Page;
            p?.NavigationService.Navigate(cp);
        }

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;


    }
}
