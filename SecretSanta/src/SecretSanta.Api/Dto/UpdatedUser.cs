using SecretSanta.Data;

using System.Collections.Generic;
namespace SecretSanta.Api.Dto
{
    public interface IUserRepository
    {
        ICollection<User> List();
        User? GetItem(int id);
        bool Remove(int id);
        User Create(User item);
        void Save(User item);
    }
    //DTO
    //Domain Transfer Object
    public class UpdatedUser
    {
        public string? FirstName { get; set; }
    }
            public class UserRepository : IUserRepository
    {
        public User Create(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            MockData.Users[item.Id] = item;
            return item;
        }

        public User? GetItem(int id)
        {
            if (MockData.Users.TryGetValue(id, out User? user))
            {
                return user;
            }
            return null;
        }

        public ICollection<User> List()
        {
            return MockData.Users.Values;
        }

        public bool Remove(int id)
        {
            return MockData.Users.Remove(id);
        }

        public void Save(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            MockData.Users[item.Id] = item;
        }
    }
}
