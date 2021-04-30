using System.Collections.Generic;
using UserGroup.Business;
using UserGroup.Data;

namespace UserGroup.Api.Tests.Business
{
    public class TestableEventManager : IEventManager
    {
        public Event Create(Event item)
        {
            throw new System.NotImplementedException();
        }

        public Event? GetItemEvent { get; set; }
        public int GetItemId { get; set; }
        public Event? GetItem(int id)
        {
            GetItemId = id;
            return GetItemEvent;
        }

        public ICollection<Event> List()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Event? SavedEvent {get; set;}
        public void Save(Event item)
        {
            SavedEvent = item;
        }
    }
}