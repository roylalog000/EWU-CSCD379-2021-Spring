using System.Collections.Generic;
using UserGroup.Data;

namespace UserGroup.Business
{
    public interface IEventManager
    {
        ICollection<Event> List();
        Event? GetItem(int id);
        bool Remove(int id);
        Event Create(Event item);
        void Save(Event item);
    }
}