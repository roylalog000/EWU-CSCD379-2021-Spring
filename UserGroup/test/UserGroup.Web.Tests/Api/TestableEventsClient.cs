using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserGroup.Web.Api;

namespace UserGroup.Web.Tests.Api
{
    public class TestableEventsClient : IEventsClient
    {
        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<Event> GetAllEventsReturnValue { get; set; } = new();
        public int GetAllAsyncInvocationCount { get; set; }
        public Task<ICollection<Event>?> GetAllAsync()
        {
            GetAllAsyncInvocationCount++;
            return Task.FromResult<ICollection<Event>?>(GetAllEventsReturnValue);
        }

        public Task<ICollection<Event>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Event> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Event> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public int PostAsyncInvocationCount { get; set; }
        public List<Event> PostAsyncInvokedParameters { get; } = new();
        public Task<Event> PostAsync(Event myEvent)
        {
            PostAsyncInvocationCount++;
            PostAsyncInvokedParameters.Add(myEvent);
            return Task.FromResult(myEvent);
        }

        public Task<Event> PostAsync(Event myEvent, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<FileResponse> PutAsync(int id, UpdateEvent updatedEvent)
        {
            throw new System.NotImplementedException();
        }

        public Task<FileResponse> PutAsync(int id, UpdateEvent updatedEvent, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}