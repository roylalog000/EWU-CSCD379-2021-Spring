using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Tests.Business
{
    internal class TestableUserRepository : IUserRepository
    {
        private Dictionary<int, User> Users { get; } = new();

        public Task<User> Create(User item)
        {
            Users.Add(item.Id, item);
            return item;
        }

        public Task<User?> GetItem(int id)
        {
            Users.TryGetValue(id, out User? rv);
            return rv;
        }

        public ICollection<User> List() => Users.Values;

        public Task<bool> Remove(int id) => Users.Remove(id);

        public Task Save(User item) => Users[item.Id] = item;

        public Task<List<User>> GetAssignmentUsers(int id)
        {

        }

        public List<Gift> GetGifts(int id)
        {
            
        }
    }
}
