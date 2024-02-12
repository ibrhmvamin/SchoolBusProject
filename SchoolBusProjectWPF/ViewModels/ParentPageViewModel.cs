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

        public ParentRepository Repository { get; set; }
        public ICommand AddParentCommand { get; set; }

        private ObservableCollection<Parent> _parents { get; set; }
        public ObservableCollection<Parent> Parents { get => _parents; set { _parents = value; OnPropertyChanged(); } }


        public ParentPageViewModel()
        {
            Repository = new ParentRepository();
            Parents= new ObservableCollection<Parent>(Repository.GetAll());
            AddParentCommand = new RelayCommand(ToNewParentPage);
        }

        public void ToNewParentPage(object? param)
        {
            var nsp = new NewParentWindow();
            nsp.DataContext = new NewParentWindowModel();
            nsp.Show();
        }
    }
}
