namespace SchoolBusDomainLayer.Entities.Abstracts
{
    public abstract class BaseUserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
