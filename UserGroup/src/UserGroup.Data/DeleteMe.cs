using System.Collections.Generic;

namespace UserGroup.Data
{
    public static class DeleteMe
    {
        public static List<Event> Events { get; } = new()
        {
            new Event() { Id = 1, Title = "Stoke's Birthday", Date= new System.DateTime(1975, 8, 6) },
            new Event() { Id = 2, Title = "Other Fun Activity", Date = new System.DateTime(2021, 5, 11) },
            new Event() { Id = 3, Title = "Someone Else's Birthday", Date = new System.DateTime(1973, 5, 1) }
        };
    }
}