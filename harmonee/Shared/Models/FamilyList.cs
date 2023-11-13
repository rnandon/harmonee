using System.Text;

namespace harmonee.Shared.Models
{
    public class FamilyList
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string[] Items { get; set; }

        public bool IsValid(out string errors, bool update = false)
        {
            var isValid = true;
            var allErrors = new StringBuilder();
            if (Id == Guid.Empty)
            {
                if (update)
                {
                    isValid = false;
                    allErrors.AppendLine("Cannot update non-existent record");
                }
                else
                {
                    Id = new Guid();
                }
            }

            if (FamilyId == Guid.Empty)
            {
                isValid = false;
                allErrors.AppendLine("Family id must have non-empty value");
            }

            errors = allErrors.ToString();
            return isValid;
        }
    }
}
