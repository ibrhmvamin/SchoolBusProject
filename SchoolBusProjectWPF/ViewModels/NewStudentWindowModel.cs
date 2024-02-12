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
    public class NewStudentWindowModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _firstname;
        public string Firstname
        { get { return _firstname; } set { _firstname=value;OnPropertyChanged();     } }

        private string _lastname;
        public string Lastname
        { get { return _lastname; } set { _lastname = value; OnPropertyChanged(); } }

        private ObservableCollection<Parent> _parents;
        public ObservableCollection<Parent> Parents
        { get { return _parents; } set { _parents = value; OnPropertyChanged(); } }

        private ObservableCollection<S_Class> _s_Class;
        public ObservableCollection<S_Class> S_Class
        { get { return _s_Class; } set { _s_Class = value; OnPropertyChanged(); } }

        private string _selectedClass;
        public string SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged();
            }
        }
        

        private string _homeAddress;
        public string HomeAddress
        { get { return _homeAddress; } set { _homeAddress = value; OnPropertyChanged(); } }

        private string _otherAddress;
        public string OtherAddress
        { get { return _otherAddress; } set { _otherAddress = value; OnPropertyChanged(); } }

        public ICommand CreateStudentCommand { get; set; }
        public StudentRepository StudentRepository { get; set; }
        public S_ClassRepository ClassRepository { get; set; }

        public NewStudentWindowModel() 
        {
            CreateStudentCommand = new RelayCommand(CreateStudentInDatabase);
            StudentRepository = new StudentRepository();
            ClassRepository=new S_ClassRepository();
            S_Class = new ObservableCollection<S_Class>(ClassRepository.GetAll());
        }

        public void CreateStudentInDatabase(object? param)
        {
            try
            {
                var s = new Student();
                s.Firstname = Firstname;
                s.Lastname = Lastname;
                s.Parents = Parents;
                s.HomeAddress = HomeAddress;
                s.OtherAddress = OtherAddress;
                S_Class? classId = ClassRepository.GetByName(SelectedClass);
                s.S_ClassId = classId.Id;
                StudentRepository.Add(s);
                StudentRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
