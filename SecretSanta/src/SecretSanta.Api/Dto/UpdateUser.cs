﻿using System;
namespace SecretSanta.Api.Dto
{
    public class UpdateUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Id{ get; set; }
        public DateTime? Date { get; set; }
    }
}
