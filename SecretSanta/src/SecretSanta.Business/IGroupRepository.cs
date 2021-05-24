using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IGroupRepository
    {
        ICollection<Group> List();
        Group? GetItem(int id);
        bool Remove(int id);
        Group Create(Group item);
        AssignmentResult GroupAssignment(int groupId);
        void Save(Group item);
        bool RemoveUser(int groupId, int userId);
    }

}
