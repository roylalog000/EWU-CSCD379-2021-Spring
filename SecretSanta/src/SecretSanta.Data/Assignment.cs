using System.Collections.Generic;
using System;

namespace SecretSanta.Data
{
    
    public class Assignment
    {
public Assignment(){}
        public int Id {get; set;}
        public User Giver { get; set; }
        public User Receiver { get; set; }
        public int GroupId { get; set; }
        public List<Group> Groups { get; } = new();
public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));
        }
        
        public String GiverReciever  {get; set;}

    }
}