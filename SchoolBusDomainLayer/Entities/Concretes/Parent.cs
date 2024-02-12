using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class Parent:BaseUserEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
