using System;
using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        public Random Random { get; }
        

        private User GetRandomUser() 
            => MockData.Users[Random.Next(MockData.Users.Count)];

        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
            return item;
        }

        public Group? GetItem(int id)
        {
            if (MockData.Groups.TryGetValue(id, out Group? user))
            {
                return user;
            }
            return null;
        }

        public ICollection<Group> List()
        {
            return MockData.Groups.Values;
        }

        public bool Remove(int id)
        {
            return MockData.Groups.Remove(id);
        }
        public Assignment? createAssignment(User give, User rec){
            Assignment newass = new Assignment(give, rec);
            return newass;
        }
    public AssignmentResult GroupAssignment(int groupId)
        {
            System.Random random = new System.Random();
            Group? group = GetItem(groupId);
            //int num = Random.Next(3);  
            //int num1 = Random.Next(3);  
            if(group.Users.Count < 3)
            {
                return AssignmentResult.Error("Not enough users in group");
            }

            if(group.Assignments.Count != 0)
            {
                group.Assignments.Clear();
            }

            List<User> userList = new List<User>();
            userList = group.Users;

            for(int i = 0;i < group.Users.Count;i++)
            {
                User randUser = userList[random.Next(userList.Count)];
                while(randUser.Id == group.Users[i].Id)
                {
                    randUser = userList[random.Next(userList.Count)];
                }
                userList.Remove(randUser);
                group.Assignments.Add(new Assignment(group.Users[i],randUser));
            }

                return AssignmentResult.Success();
            
            
        }
        //public addtoAssignment(User)
        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
        }

        public bool RemoveUser(int groupId, int userId)
        {
            Group? foundGroup = GetItem(groupId);
            if(foundGroup is not null)
            {
                User? foundUser = foundGroup.Users.FirstOrDefault(x => x.Id == userId);
                if(foundUser is not null)
                {
                    foundGroup.Users.Remove(foundUser);
                    return true;
                }
            }
            return false;
        }
    }
}
