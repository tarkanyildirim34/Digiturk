namespace Digiturk.Core.Domain.Catalog
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
    }
}
