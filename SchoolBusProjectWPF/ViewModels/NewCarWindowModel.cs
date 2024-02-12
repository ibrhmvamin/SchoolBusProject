using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
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
    public class NewCarWindowModel:INotifyPropertyChanged
    {

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CreateCarCommand { get; set; }

        public CarRepository CarRepository { get; set; }

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

        private int _seatCount;
        public int SeatCount
        {
            get { return _seatCount; }
            set
            {
                _seatCount = value;
                OnPropertyChanged();

            }
        }

        private int _driverId;
        public int DriverId
        {
            get { return _driverId; }
            set
            {
                _driverId = value;
                OnPropertyChanged();

            }
        }

        public NewCarWindowModel()
        {
            CarRepository = new CarRepository();           
            CreateCarCommand = new RelayCommand(AddCarToDatabase);
        }

        public void AddCarToDatabase(object? param)
        {
            try
            {
                var c = new Car();
                c.Name = Name;
                c.Number = Number;
                c.SeatCount = SeatCount;
                CarRepository.Add(c);
                CarRepository.SaveChanges();               
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
