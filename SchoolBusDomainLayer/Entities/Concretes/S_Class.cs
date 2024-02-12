using SchoolBusDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class S_Class : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
