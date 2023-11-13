namespace harmonee.Shared.Models
{
    public class FamilyMember
    {
        public Guid FamilyId { get; set; }
        public Guid UserId { get; set; }

        public bool IsValid(out string errors)
        {
            errors = string.Empty;
            return FamilyId != Guid.Empty && UserId != Guid.Empty;
        }
    }
}
