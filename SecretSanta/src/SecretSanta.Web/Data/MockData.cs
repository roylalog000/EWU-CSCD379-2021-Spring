using System;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<EventViewModel> Events = new List<EventViewModel>{
            new EventViewModel {Id = 0, Title = "First Presentation", Description = "Simple Description", Date = DateTime.Now.AddMonths(-2), Location="IntelliTect Office", SpeakerId = 0},
            new EventViewModel {Id = 1, Title = "Second Presentation", Description = "Another simple description", Date = DateTime.Now.AddMonths(-1), Location="IntelliTect Office", SpeakerId = 1},
        };

        public static List<NameViewModel> Name = new List<NameViewModel>{
            new NameViewModel {Id = 0, FirstName = "Inigo", LastName = "Montoya"},
            new NameViewModel {Id = 1, FirstName = "Princess", LastName = "Buttercup"},
        };
         public static List<GroupViewModel> Group = new List<GroupViewModel>{
            new GroupViewModel {Id = 0, Group = "Barney and Friends"},
            
        };
        public static List<GiftViewModel> Gift = new List<GiftViewModel>{
            new GiftViewModel {Id = 0, Title="Raisin Bran", Description="Delicious healthy cereal", URL="https://www.kelloggs.com/en_US/brands/kellogg-s-raisin-bran-consumer-brand.html", Priority=3, UserID = 0}, 
            
        };
    }
}