using SchoolBusDataAccess.Contexts;
using SchoolBusDataAccess.Repositories.Abstract;
using SchoolBusDomainLayer.Entities.Abstracts;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        internal readonly SchoolBusDBContext _dbContext;

        public BaseRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }
        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Data is null");
            _dbContext?.Set<T>().Add(entity);
        }

        public ICollection<T>? GetAll()
        {
            return _dbContext.Set<T>().ToList();   
        }

        public T? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Data is null");
            var c = _dbContext?.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (c != null) throw new ArgumentException("Data is null");
            _dbContext?.Set<T>().Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("Data is null");
            var c = _dbContext?.Set<T>().FirstOrDefault(x => x.Id == id);
            if (c != null) throw new ArgumentException("Data is null");
            _dbContext?.Set<T>().Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Data is null");
            var c = _dbContext?.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (c != null) throw new ArgumentException("Data is null");
            _dbContext?.Set<T>().Update(c);
        }
    }
}
