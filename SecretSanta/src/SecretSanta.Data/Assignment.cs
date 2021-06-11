using System.Collections.Generic;
using System;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int AssignmentId {get; set;}
        public int GroupId {get; set;}

        public User Giver { get; set; }
        public int GiverId { get; set; }
        public User Receiver { get; set; }
        public int ReceiverId { get; set; }

        public Group Group {get; set;}
        

        public Assignment() {  }

        public Assignment(User giver, User receiver)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        }
    }
}