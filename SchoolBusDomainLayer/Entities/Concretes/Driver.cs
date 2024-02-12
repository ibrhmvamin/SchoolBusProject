using SchoolBusDomainLayer.Entities.Abstracts;
namespace SchoolBusDomainLayer.Entities.Concretes
{
    public class Driver:BaseUserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Licence { get; set; }
        public virtual Car Car { get; set; }
    }
}
