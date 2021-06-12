using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Group
    {
//        public int Id { get; set; }
        public string Name { get; set; } = "";
    public int GroupId { get; set; }
    //public List<GroupUser> GroupUser { get; } = new();
        public List<User> Users { get; } = new();
        public List<Assignment> Assignments { get; } = new();
    }
}
