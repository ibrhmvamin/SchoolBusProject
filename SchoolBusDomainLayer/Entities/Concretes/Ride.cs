using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class Ride:BaseEntity
    {
        public string Name { get; set; }     
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
