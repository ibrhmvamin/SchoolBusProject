using SchoolBusDataAccess.Contexts;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class DriverRepository:BaseRepository<Driver>
    {
        internal readonly SchoolBusDBContext _dbContext;

        public DriverRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }

        public void Add(Driver Driver)
        {
            if (Driver == null) throw new ArgumentNullException("Driver is null");
            _dbContext.Drivers.Add(Driver);
        }

        public ICollection<Driver> GetAll()
        {
            return _dbContext.Drivers.ToList();
        }

        public Driver? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.Drivers.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Driver Driver)
        {
            if (Driver == null) throw new ArgumentNullException("Driver is null");
            var c = _dbContext?.Drivers.FirstOrDefault(x => x.Id == Driver.Id);
            if (c != null) throw new ArgumentException("Driver is null");
            _dbContext?.Drivers.Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("Driver is null");
            var c = _dbContext?.Drivers.FirstOrDefault(x => x.Id == id);
            if (c != null) throw new ArgumentException("Driver is null");
            _dbContext?.Drivers.Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Driver Driver)
        {
            if (Driver == null) throw new ArgumentNullException("Driver is null");
            var c = _dbContext?.Drivers.FirstOrDefault(x => x.Id == Driver.Id);
            if (c != null) throw new ArgumentException("Driver is null");
            _dbContext?.Drivers.Update(c);
        }


    }
}

