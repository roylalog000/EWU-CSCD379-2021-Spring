using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class DeleteMe
    {
        public static List<User> Users {get;} = new()
        {
            new User() { Id = 1, FirstName = "Inigo", LastName = "Montoya"},
            new User() { Id = 2, FirstName = "Billy", LastName = "Eichner"},
            new User() { Id = 3, FirstName = "Paul", LastName = "Bunyan"}
        };
    }
}