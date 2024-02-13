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

    
    public class ParentPageViewModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private Parent _selectedParent;

        public Parent SelectedParent
        {
            get { return _selectedParent; }
            set { _selectedParent = value; OnPropertyChanged(); }
        }
        public ParentRepository Repository { get; set; }
        public ICommand AddParentCommand { get; set; }
        public ICommand EditParentCommand { get; set; }
        public ICommand RemoveParentCommand { get; set; }

        private ObservableCollection<Parent> _parents { get; set; }
        public ObservableCollection<Parent> Parents { get => _parents; set { _parents = value; OnPropertyChanged(); } }


        public ParentPageViewModel()
        {
            Repository = new ParentRepository();
            Parents= new ObservableCollection<Parent>(Repository.GetAll());
            AddParentCommand = new RelayCommand(ToNewParentPage);
            EditParentCommand = new RelayCommand(EditParent);
            RemoveParentCommand = new RelayCommand(RemoveParent);
        }

        public void RemoveParent(object? param)
        {
            try
            {
                Repository.Remove(SelectedParent);
                Repository.SaveChanges();
                MessageBox.Show("Parent deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditParent(object? param)
        {
            try
            {
                if (SelectedParent != null)
                {
                    Repository.Update(SelectedParent);
                    Repository.SaveChanges();
                    MessageBox.Show("Parent edited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ToNewParentPage(object? param)
        {
            var nsp = new NewParentWindow();
            nsp.DataContext = new NewParentWindowModel();
            nsp.Show();
        }
    }
}
