using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Tests.Business
{
    internal class TestableGroupRepository : IGroupRepository
    {
        private Dictionary<int, Group> Groups { get; } = new();

        public Task<Group> Create(Group item)
        {
            Groups.Add(item.Id, item);
            return item;
        }

        public AssignmentResult? AssignmentResult { get; set; }
        public Task<AssignmentResult> GenerateAssignments(int groupId)
        {
            return AssignmentResult ?? throw new InvalidOperationException();
        }

        public Task<Group?> GetItem(int id)
        {
            Groups.TryGetValue(id, out Group? rv);
            return rv;
        }

        public ICollection<Group> List() => Groups.Values;

        public Task<bool> Remove(int id) => Groups.Remove(id);

        public Task Save(Group item) => Groups[item.Id] = item;

        public Task<bool> AddUser(int groupId, int userId)
        {

        }

        public Task<bool> RemoveUser(int groupId, int userId)
        {

        }

        public Task<List<User>> GetUsers(int groupId)
        {

        }
        
        public IQueryable<Assignment> GetAssignments(int groupId)
        {

        }

    }
}
