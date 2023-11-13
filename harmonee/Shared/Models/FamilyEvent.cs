using System.Text;

namespace harmonee.Shared.Models
{
    public class FamilyEvent
    {
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CreatedBy { get; set; }

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

            if (CreatedBy == Guid.Empty)
            {
                isValid = false;
                allErrors.AppendLine("Creator id must have non-empty value");
            }

            if (FamilyId == Guid.Empty)
            {
                isValid = false;
                allErrors.AppendLine("Family id must have non-empty value");
            }

            if (StartTime == DateTime.MinValue || EndTime == DateTime.MinValue) 
            {
                isValid = false;
                allErrors.AppendLine("Start and end times must be specified");
            }

            errors = allErrors.ToString();
            return isValid;
        }
    }
}
