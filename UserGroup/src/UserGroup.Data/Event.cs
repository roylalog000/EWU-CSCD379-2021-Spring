using System;
using System.Collections.Generic;

namespace UserGroup.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public DateTime? Date { get; set; }
        public string? Location { get; set; } = "";
        public List<Speaker> Speakers { get; } = new();
    }
}