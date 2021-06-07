using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<User> Users { get; } = new();
        //f
        public List<Assignment> Assignments { get; } = new();

        //Gives foreign key to assignemtn creating a many to many
    }
}
