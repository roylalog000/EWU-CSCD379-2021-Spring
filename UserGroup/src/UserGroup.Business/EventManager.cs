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
            item.Id = DeleteMe.Events.Max(s => s.Id) + 1;
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

        public RemoveSpeakerResult RemoveSpeaker(int eventId, int speakerId)
        {
            Event? foundEvent = DeleteMe.Events.FirstOrDefault(x => x.Id == eventId);
            if (foundEvent is not null)
            {
                Speaker? foundSpeaker = foundEvent.Speakers.FirstOrDefault(x => x.Id == speakerId);
                if (foundSpeaker is not null)
                {
                    foundEvent.Speakers.Remove(foundSpeaker);
                    return RemoveSpeakerResult.Success();
                }
                return RemoveSpeakerResult.SpeakerNotFound();
            }
            return RemoveSpeakerResult.EventNotFound();
        }

        public void Save(Event item)
        {
            Remove(item.Id);
            Create(item);
        }
    }

    public class RemoveSpeakerResult
    {
        public bool IsSuccess => string.IsNullOrWhiteSpace(ErrorMessage);
        public string? ErrorMessage { get; }

        private RemoveSpeakerResult(string? errorMessage) 
        { 
            ErrorMessage = errorMessage;
        }

        public static RemoveSpeakerResult SpeakerNotFound()
            => new RemoveSpeakerResult("Speaker not found");

        public static RemoveSpeakerResult EventNotFound()
            => new RemoveSpeakerResult("Event not found");
        
        public static RemoveSpeakerResult Success()
            => new RemoveSpeakerResult(null);
    }
}