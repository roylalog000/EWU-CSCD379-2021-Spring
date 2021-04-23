using System;
using System.Collections.Generic;
using UserGroup.Data;
using System.Linq;

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
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return DeleteMe.Events.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Event> List()
        {
            return DeleteMe.Events;
        }

        public bool Remove(int id)
        {
            Event? foundEvent = DeleteMe.Events.FirstOrDefault(x => x.Id == id);
            if (foundEvent is not null)
            {
                DeleteMe.Events.Remove(foundEvent);
                return true;
            }
            return false;
        }

        public void Save(Event item)
        {
            Remove(item.Id);
            Create(item);
        }
    }
}