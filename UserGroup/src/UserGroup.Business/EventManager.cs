using System.Collections.Generic;
using UserGroup.Data;

namespace UserGroup.Business
{
    public class EventManager : IEventManager
    {
        public Event Create(Event item)
        {
            DeleteMe.Events.Add(item);
            return item;
        }

        public Event? GetItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Event> List()
        {
            return DeleteMe.Events;
        }

        public bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Event item)
        {
            throw new System.NotImplementedException();
        }
    }
}