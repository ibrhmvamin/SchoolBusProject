using SchoolBusDataAccess.Contexts;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class StudentRepository:BaseRepository<Student>
    {
        internal readonly SchoolBusDBContext _dbContext;

        public StudentRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }

        public void Add(Student Student)
        {
            if (Student == null) throw new ArgumentNullException("Student is null");
            _dbContext.Students.Add(Student);
        }

        public ICollection<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public Student? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Student Student)
        {
            if (Student == null) throw new ArgumentNullException("Student is null");
            var c = _dbContext?.Students.FirstOrDefault(x => x.Id == Student.Id);
            if (c == null) throw new ArgumentException("Student is null");
            _dbContext?.Students.Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("Student is null");
            var c = _dbContext?.Students.FirstOrDefault(x => x.Id == id);
            if (c == null) throw new ArgumentException("Student is null");
            _dbContext?.Students.Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Student Student)
        {
            if (Student == null) throw new ArgumentNullException("Student is null");
            var c = _dbContext?.Students.FirstOrDefault(x => x.Id == Student.Id);
            if (c == null) throw new ArgumentException("Student is null");
            _dbContext?.Students.Update(c);
        }
    }
}
