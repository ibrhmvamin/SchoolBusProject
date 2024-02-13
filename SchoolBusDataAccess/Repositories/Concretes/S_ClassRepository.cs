using SchoolBusDataAccess.Contexts;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class S_ClassRepository:BaseRepository<S_Class>
    {
        internal readonly SchoolBusDBContext _dbContext;

        public S_ClassRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }

        public void Add(S_Class S_Class)
        {
            if (S_Class == null) throw new ArgumentNullException("S_Class is null");
            _dbContext.S_Classes.Add(S_Class);
        }

        public ICollection<S_Class> GetAll()
        {
            return _dbContext.S_Classes.ToList();
        }

        public S_Class? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.S_Classes.FirstOrDefault(x => x.Id == id);
        }
        public S_Class GetByName(string name)
        {
            if (name is null) throw new ArgumentOutOfRangeException("name can not be null");
            return _dbContext.S_Classes.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(S_Class S_Class)
        {
            if (S_Class == null) throw new ArgumentNullException("S_Class is null");
            var c = _dbContext?.S_Classes.FirstOrDefault(x => x.Id == S_Class.Id);
            if (c == null) throw new ArgumentException("S_Class is null");
            _dbContext?.S_Classes.Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("S_Class is null");
            var c = _dbContext?.S_Classes.FirstOrDefault(x => x.Id == id);
            if (c == null) throw new ArgumentException("S_Class is null");
            _dbContext?.S_Classes.Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(S_Class S_Class)
        {
            if (S_Class == null) throw new ArgumentNullException("S_Class is null");
            var c = _dbContext?.S_Classes.FirstOrDefault(x => x.Id == S_Class.Id);
            if (c == null) throw new ArgumentException("S_Class is null");
            _dbContext?.S_Classes.Update(c);
        }
    }
}
