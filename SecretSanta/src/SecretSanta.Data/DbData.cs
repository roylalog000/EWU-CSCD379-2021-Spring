using System.Collections.Generic;
using System.Linq;


//Example data to load into the database. Loads every start. The database deletes itself every run so these values are new every time
namespace SecretSanta.Data{
    public class DbData{
        public static List<User> Users(){
            return new List<User>{
                new User()
                {
                    UserId = 1,
                    FirstName = "Inigo",
                    LastName = "Montoya"
                },
                new User
                {
                    UserId = 2,
                    FirstName = "Princess",
                    LastName = "Buttercup"
                },
                new User
                {
                    UserId = 3,
                    FirstName = "Prince",
                    LastName = "Humperdink"
                },
                new User
                {
                    UserId = 4,
                    FirstName = "Count",
                    LastName = "Rugen"
                },
                new User
                {
                    UserId = 5,
                    FirstName = "Miracle",
                    LastName = "Max"
                },new User
                {
                    UserId = 6,
                    FirstName = "Some",
                    LastName = "Guyg"
                }
            };
        }
        public static List<GroupUser> GroupUsers(){
            return new List<GroupUser>{
                new GroupUser{
                    GroupId = 1,
                    UserId = 1
                },new GroupUser{
                    GroupId = 1,
                    UserId = 2
                },new GroupUser{
                    GroupId = 1,
                    UserId = 6
                },new GroupUser{
                    GroupId = 2,
                    UserId = 3
                },
                new GroupUser{
                    GroupId = 2,
                    UserId = 4
                },new GroupUser{
                    GroupId = 2,
                    UserId = 5
                },

            };
        }
        public static List<Gift> Gifts(){
            return new List<Gift>{
                new Gift{
                    GiftId = 1,
                    UserId = 1,
                    RecieverId = 2,
                    Name = "TV",
                    

                },new Gift{
                    GiftId = 2,
                    UserId = 2,
                    RecieverId = 6,
                    Name = "radio",
                   

                },new Gift{
                    GiftId = 3,
                   UserId = 3,
                    RecieverId = 4,
                    Name = "knock off digigmon cards",
                    

                },new Gift{
                    GiftId = 4,
                    UserId = 4,
                    RecieverId = 5,
                    Name = "a hug",
                   

                },new Gift{
                    GiftId = 5,
                    UserId = 5,
                    RecieverId = 3,
                    Name = "A pair of socks",
                   
                },new Gift{
                    GiftId = 6,
                    UserId = 6,
                    RecieverId = 1,
                    Name = "Elmo does laundry the novel",
                   
                },
            };
        }
        
        public static List<Assignment> Assignments(){
            return new List<Assignment>{
            new Assignment
                {
                    AssignmentId = 1,
                    GiverId = 1,
                    ReceiverId = 2,
                    GroupId = 1
                
                }, new Assignment
                {
                    AssignmentId = 2,
                    GiverId = 2,
                    ReceiverId = 6,
                    GroupId = 1
                
                }, new Assignment
                {
                    AssignmentId = 3,
                    GiverId = 3,
                    ReceiverId = 4,
                    GroupId = 2
                
                }, new Assignment
                {
                    AssignmentId = 4,
                    GiverId = 4,
                    ReceiverId = 5,
                    GroupId = 2
                
                },new Assignment
                {
                    AssignmentId = 5,
                    GiverId = 5,
                    ReceiverId = 3,
                    GroupId = 2
                
                },new Assignment
                {
                    AssignmentId = 6,
                    GiverId = 6,
                    ReceiverId = 1,
                    GroupId = 1
                
                },
        };
        }
        public static List<Group> Groups(){
            return new List<Group>{
                new Group
                    {
                        GroupId = 1,
                        Name = "IntelliTect Christmas Party"
                    },
                new Group
                {
                    GroupId = 2,
                    Name = "The Band, Ghost"
                }
                
            };
        }
    }   
}