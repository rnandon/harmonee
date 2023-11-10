using harmonee.Areas.Identity.Data;

namespace harmonee.Areas.Core.Data
{
    public class Family
    {
        public Guid Id { get; set; }
        public List<User> Members { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
