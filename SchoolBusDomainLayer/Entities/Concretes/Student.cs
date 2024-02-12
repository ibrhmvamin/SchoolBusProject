using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class Student:BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string HomeAddress { get; set; }
        public string? OtherAddress { get; set; }
        public int S_ClassId { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
        public virtual S_Class S_Class { get; set; }
        public virtual ICollection<Ride> Rides { get; set; }
        public int RideId { get; set; }
    }
}
