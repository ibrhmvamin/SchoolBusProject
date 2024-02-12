using SchoolBusDataAccess.Contexts;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class ParentRepository:BaseRepository<Parent>
    {
        internal readonly SchoolBusDBContext _dbContext;

        public ParentRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }

        public void Add(Parent Parent)
        {
            if (Parent == null) throw new ArgumentNullException("Parent is null");
            _dbContext.Parents.Add(Parent);
        }

        public ICollection<Parent> GetAll()
        {
            return _dbContext.Parents.ToList();
        }

        public Parent? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.Parents.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Parent Parent)
        {
            if (Parent == null) throw new ArgumentNullException("Parent is null");
            var c = _dbContext?.Parents.FirstOrDefault(x => x.Id == Parent.Id);
            if (c != null) throw new ArgumentException("Parent is null");
            _dbContext?.Parents.Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("Parent is null");
            var c = _dbContext?.Parents.FirstOrDefault(x => x.Id == id);
            if (c != null) throw new ArgumentException("Parent is null");
            _dbContext?.Parents.Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Parent Parent)
        {
            if (Parent == null) throw new ArgumentNullException("Parent is null");
            var c = _dbContext?.Parents.FirstOrDefault(x => x.Id == Parent.Id);
            if (c != null) throw new ArgumentException("Parent is null");
            _dbContext?.Parents.Update(c);
        }


    }
}

