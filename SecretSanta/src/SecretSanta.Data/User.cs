using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class User
    {
        //public int Id { get; set; }
        public int UserId { get; set; }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        //public List<GroupUser> GroupUser { get; } = new();
       // public List<Group> Groups { get; } = new();
        ///public List<Gift> Gifts { get;} = new();
    }
}
