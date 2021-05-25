using System;
using System.Collections.Generic;
using UserGroup.Web.ViewModels;

namespace UserGroup.Web.Data
{
    public static class MockData
    {
        public static List<EventViewModel> Events = new List<EventViewModel>{
            new EventViewModel {Id = 0, Title = "First Presentation", Description = "Simple Description", Date = DateTime.Now.AddMonths(-2), Location="IntelliTect Office", SpeakerId = 0},
            new EventViewModel {Id = 1, Title = "Second Presentation", Description = "Another simple description", Date = DateTime.Now.AddMonths(-1), Location="IntelliTect Office", SpeakerId = 1},
        };

        public static List<SpeakerViewModel> Speakers = new List<SpeakerViewModel>{
            new SpeakerViewModel {Id = 0, FirstName = "Inigo", LastName = "Montoya", EmailAddress = "Inigo.Montoya@princessbride.com"},
            new SpeakerViewModel {Id = 1, FirstName = "Princess", LastName = "Buttercup", EmailAddress = "Princess.Buttercup@princessbride.com"},
            new SpeakerViewModel {Id = 2, FirstName = "Prince", LastName = "Humperdink", EmailAddress = "Prince.Humperdink@princessbride.com"},
            new SpeakerViewModel {Id = 3, FirstName = "Miracle", LastName = "Max", EmailAddress = "Miracle.Max@princessbride.com"},
            new SpeakerViewModel {Id = 4, FirstName = "Count", LastName = "Rugen", EmailAddress = "Inigo.Montoya@princessbride.com"},
        };
    }
}