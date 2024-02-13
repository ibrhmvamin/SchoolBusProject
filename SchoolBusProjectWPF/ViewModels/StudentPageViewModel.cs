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
    public class StudentPageViewModel:INotifyPropertyChanged
    {

    private Student _selectedStudent;

    public Student SelectedStudent
    {
        get { return _selectedStudent; }
        set { _selectedStudent = value; OnPropertyChanged(); }
    }
        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public StudentRepository StudentRepository { get; set; }
        public ParentRepository ParentRepository { get; set; }
        public S_ClassRepository ClassRepository { get; set; }

        private ObservableCollection<Parent> _parents { get; set; }
        public ObservableCollection<Parent> Parents { get => _parents; set { _parents = value; OnPropertyChanged(); } }

        private ObservableCollection<Student> _students { get; set; }
        public ObservableCollection<Student> Students { get => _students; set { _students = value; OnPropertyChanged(); } }

        private ObservableCollection<S_Class> _s_Class { get; set; }
        public ObservableCollection<S_Class> S_Class { get => _s_Class; set { _s_Class = value; OnPropertyChanged(); } }
        public ICommand EditStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public StudentPageViewModel()
        {
            AddStudentCommand = new RelayCommand(AddStudentPage);
            EditStudentCommand = new RelayCommand(EditStudentInDatabase);
            RemoveStudentCommand = new RelayCommand(RemoveStudentFromDatabase);
            StudentRepository =new StudentRepository();
            ParentRepository=new ParentRepository();
            ClassRepository=new S_ClassRepository();
            Students = new ObservableCollection<Student>(
       StudentRepository.GetAll()
                        .Select(s => new Student
                        {
                            Id = s.Id,
                            Firstname = s.Firstname,
                            Lastname = s.Lastname,
                            HomeAddress = s.HomeAddress,
                            OtherAddress = s.OtherAddress,
                            S_ClassId = s.S_ClassId
                        })
                        .ToList());
   
               S_Class =new ObservableCollection<S_Class>(ClassRepository.GetAll()
                   .Select(s => new S_Class
                   {
                       Name = s.Name
                   }).ToList());

            Parents = new ObservableCollection<Parent>(ParentRepository.GetAll()
        .Select(p => new Parent
        {
            Firstname = p.Firstname
        })
        .ToList());

        }

        private void EditStudentInDatabase(object? obj)
        {
            try
            {
                if (SelectedStudent != null)
                {
                    StudentRepository.Update(SelectedStudent);
                    StudentRepository.SaveChanges();
                    MessageBox.Show("Edited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void RemoveStudentFromDatabase(object? param)
        {
            try
            {
                StudentRepository.Remove(SelectedStudent);
                StudentRepository.SaveChanges();
                MessageBox.Show("Student deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddStudentPage(object? param)
        {
           var nsp = new NewStudentWindow();
            nsp.DataContext = new NewStudentWindowModel();
            nsp.Show();
        }
    }
}
