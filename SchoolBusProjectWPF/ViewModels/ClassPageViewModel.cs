using SchoolBusDataAccess.Repositories.Concretes;
using SchoolBusDomainLayer.Entities.Concretes;
using SchoolBusProjectWPF.Commands;
using SchoolBusProjectWPF.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SchoolBusProjectWPF.ViewModels
{
    public class ClassPageViewModel:INotifyPropertyChanged
    {
        private S_Class _selectedClass;

        public S_Class SelectedClass
        {
            get { return _selectedClass; }
            set { _selectedClass = value; OnPropertyChanged(); }
        }
        public S_ClassRepository ClassRepository { get; set; }
       

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<S_Class> _s_Class;
        public ObservableCollection<S_Class> S_Class
        {
            get { return _s_Class; }
            set
            {
                _s_Class = value;
                OnPropertyChanged();
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

        public ICommand AddClassCommand { get; set; }
       
        public ICommand EditClassCommand { get; set; }
        public ICommand RemoveClassCommand { get; set; }


        public ClassPageViewModel()
        {
            ClassRepository=new S_ClassRepository();          
            S_Class = new ObservableCollection<S_Class>(ClassRepository.GetAll());              
            AddClassCommand = new RelayCommand(NewClassWindow);
            EditClassCommand = new RelayCommand(EditClass);
            RemoveClassCommand = new RelayCommand(RemoveClass);

        }

        public void RemoveClass(object? param)
        {
            try
            {
                ClassRepository.Remove(SelectedClass);
                ClassRepository.SaveChanges();
                MessageBox.Show("Class deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditClass(object? param)
        {
            try
            {
                if (SelectedClass!=null) 
                {
                    ClassRepository.Update(SelectedClass);
                    ClassRepository.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void NewClassWindow(object? param)
        {
            var ncw = new NewClassWindow();
            ncw.DataContext = new CreateClassWindowViewModel();
            ncw.Show();
        }
    }
}
