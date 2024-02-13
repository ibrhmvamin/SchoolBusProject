using SchoolBusDataAccess.Contexts;
using SchoolBusDataAccess.Repositories.Abstract;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Concretes
{
    public class CarRepository : BaseRepository<Car>
    {
        internal readonly SchoolBusDBContext _dbContext;

        public CarRepository()
        {
            _dbContext = new SchoolBusDBContext();
        }

        public void Add(Car car)
        {
            if (car == null) throw new ArgumentNullException("Car is null");
            _dbContext.Cars.Add(car);
        }

        public ICollection<Car> GetAll()
        {
            return _dbContext.Cars.ToList();
        }

        public Car? GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id can not be less than 0");
            return _dbContext.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Car car)
        {
            if (car == null) throw new ArgumentNullException("Car is null");
            var c=_dbContext?.Cars.FirstOrDefault(x => x.Id==car.Id);
            if (c == null) throw new ArgumentException("Car is null");
            _dbContext?.Cars.Remove(c);
        }

        public void Remove(int id)
        {
            if (id <= 0) throw new ArgumentNullException("Car is null");
            var c = _dbContext?.Cars.FirstOrDefault(x => x.Id == id);
            if (c == null) throw new ArgumentException("Car is null");
            _dbContext?.Cars.Remove(c);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            if (car == null) throw new ArgumentNullException("Car is null");
            var c = _dbContext?.Cars.FirstOrDefault(x => x.Id == car.Id);
            if (c == null) throw new ArgumentException("Car is null");
            _dbContext?.Cars.Update(c);
        }

        
    }
}
