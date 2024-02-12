using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
        T? GetById(int id);
        ICollection<T>? GetAll();
        void SaveChanges();
    }
}
