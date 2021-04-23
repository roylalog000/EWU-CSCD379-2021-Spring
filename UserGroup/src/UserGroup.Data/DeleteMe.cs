using System.Collections.Generic;

namespace UserGroup.Data
{
    public static class DeleteMe
    {
        public static List<Event> Events { get; } = new()
        {
            new Event() { Id = 1, Name = "Stoke's Birthday", UserGroupSpeakers = new[] { "Bannana" } },
            new Event() { Id = 2, Name = "Other Fun Activity" },
            new Event() { Id = 3, Name = "Someone Else's Birthday" }
        };
    }
}