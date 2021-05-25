using System.Collections.Generic;
using UserGroup.Data;

namespace UserGroup.Business
{
    public interface IEventManager
    {
        ICollection<Event> List();
        Event? GetItem(int id);
        bool Remove(int id);
        RemoveSpeakerResult RemoveSpeaker(int eventId, int speakerId);
        Event Create(Event item);
        void Save(Event item);
    }
}