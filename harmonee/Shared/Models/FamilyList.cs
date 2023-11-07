namespace harmonee.Shared.Models
{
    public class FamilyList
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string[] Items { get; set; }
    }
}
