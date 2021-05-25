using System.Collections.Generic;

namespace UserGroup.Data
{
    public static class EventContext
    {
        static EventContext()
        {
            Events[0].Speakers.Add(Speakers[0]);
            Events[0].Speakers.Add(Speakers[1]);
            Events[0].Speakers.Add(Speakers[2]);
            Events[1].Speakers.Add(Speakers[2]);
            Events[2].Speakers.Add(Speakers[0]);
            Events[2].Speakers.Add(Speakers[1]);
        }

        public static List<Event> Events { get; } = new()
        {
            new Event() { Id = 1, Title = "Stoke's Birthday", Date = new System.DateTime(1975, 8, 6) },
            new Event() { Id = 2, Title = "Other Fun Activity", Date = new System.DateTime(2021, 5, 11) },
            new Event() { Id = 3, Title = "Someone Else's Birthday", Date = new System.DateTime(1973, 5, 1) }
        };

        public static List<Speaker> Speakers { get; } = new()
        {
            new Speaker() { Id = 1, FirstName = "Mike", LastName = "Jones" },
            new Speaker() { Id = 2, FirstName = "Mickey", LastName = "Mouse" },
            new Speaker() { Id = 3, FirstName = "Mountain", LastName = "Dew" }
        };
    }
}