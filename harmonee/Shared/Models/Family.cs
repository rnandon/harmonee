﻿using harmonee.Shared.Auth;
using System.Text;

namespace harmonee.Shared.Models
{
    public class Family
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid[] FamilyMemberIds { get; set; }
        public Guid[] FamilyEventIds { get; set; }
        public Guid[] FamilyListIds { get; set; }

        public bool IsValid(out string errorMessages)
        {
            var messages = new StringBuilder();
            var isValid = true;

            if (Name == string.Empty)
            {
                messages.AppendLine("Family name must have a value.");
                isValid = false;
            }
            if (FamilyMemberIds.Length == 0)
            {
                messages.AppendLine("Family must have at least one member.");
                isValid = false;
            }

            errorMessages = messages.ToString();
            return isValid;
        }

        public bool RemoveFamilyMember(Guid userId)
        {
            var currentCount = FamilyMemberIds.Length;
            FamilyMemberIds = FamilyMemberIds.Where(fmi => fmi != userId).ToArray();
            return currentCount != FamilyMemberIds.Length;
        }

        public bool RemoveFamilyEvent(Guid eventId)
        {
            var currentCount = FamilyEventIds.Length;
            FamilyEventIds = FamilyEventIds.Where(fei => fei != eventId).ToArray();
            return currentCount != FamilyEventIds.Length;
        }

        public bool RemoveFamilyList(Guid eventId)
        {
            var currentCount = FamilyListIds.Length;
            FamilyListIds = FamilyListIds.Where(fli => fli != eventId).ToArray();
            return currentCount != FamilyListIds.Length;
        }
    }

}
