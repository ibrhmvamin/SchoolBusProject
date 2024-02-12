using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class Car :BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int SeatCount { get; set; }

        public virtual Driver Driver { get; set; }
        public int DriverId { get; set; }
        public virtual IEnumerable<Ride> Rides { get; set; }
    }
}
