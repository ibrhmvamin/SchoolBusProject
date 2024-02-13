using MaterialDesignThemes.Wpf;
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
    public class DriverPageViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Driver> _drivers;
        public ObservableCollection<Driver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                OnPropertyChanged();
            }
        }

        private Driver _selectedDriver;

        public Driver SelectedDriver
        {
            get { return _selectedDriver; }
            set { _selectedDriver = value; OnPropertyChanged(); }
        }


        public DriverRepository DriverRepository { get; set; }
        public CarRepository CarRepository { get; set; }
        public ICommand AddDriverCommand { get; set; }
        public ICommand EditDriverCommand { get; set; }
       
        public ICommand RemoveDriverCommand { get; set; }

        public DriverPageViewModel()
        {
            DriverRepository = new DriverRepository();
            Drivers = new ObservableCollection<Driver>(DriverRepository.GetAll());             
            EditDriverCommand=new RelayCommand(EditDrivers);
            RemoveDriverCommand = new RelayCommand(RemoveDrivers);
            AddDriverCommand = new RelayCommand(ToNewDriverWindow);

        }

        public void EditDrivers(object? param)
        {
            try
            {
                if (SelectedDriver != null)
                {
                    DriverRepository.Update(SelectedDriver);
                   DriverRepository.SaveChanges();
                    MessageBox.Show("Edited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RemoveDrivers(object? param)
        {
            try
            {
                if (SelectedDriver != null)
                {
                    DriverRepository.Remove(SelectedDriver);
                    DriverRepository.SaveChanges();
                    MessageBox.Show("Removed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ToNewDriverWindow(object? param)
        {
            try
            {
                var ndp = new NewDriverWindow();
                ndp.DataContext = new NewDriverWindowModel();
                ndp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
    }
}
