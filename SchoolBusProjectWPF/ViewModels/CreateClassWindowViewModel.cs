using GalaSoft.MvvmLight.Messaging;
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
    public class CreateClassWindowViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _classname { get; set; }
        public string? Classname { get => _classname; set { _classname = value; OnPropertyChanged(); } }

        public S_ClassRepository ClassRepository { get; set; }
        public ICommand AddClassCommand2 { get; set; }
        public CreateClassWindowViewModel()
        {

            AddClassCommand2 = new RelayCommand(AddClassToDatabase);
            ClassRepository=new S_ClassRepository();
        }

        public void AddClassToDatabase(object? param)
        {
            var S_Class = new S_Class();
            S_Class.Name = _classname;
            ClassRepository.Add(S_Class);
            ClassRepository.SaveChanges();
            MessageBox.Show("Class Added to School Successfully");
        }
    }
}
