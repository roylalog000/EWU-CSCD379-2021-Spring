using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Gift
    {
 
    
        public int Id { get; set; }
        
        public string Description { get; set; } = "";
        public string Url { get; set; } = "";
        public int Priority { get; set; }
        public int UserId { get; set; }
    

        //public int Id { get; set; }
        public int GiftId { get; set; }
        //public User Reciever {get; set;} = new();
        public string Title { get; set; } = "";
                public string Name { get; set; } = "";

        public int RecieverId { get; set; }
        
      
        
    }
}