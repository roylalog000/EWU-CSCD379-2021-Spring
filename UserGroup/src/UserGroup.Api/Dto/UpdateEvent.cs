using System;

namespace UserGroup.Api.Dto
{
    //DTO
    //Domain Transfer Object
    public class UpdateEvent
    {
        public string? Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public DateTime? Date { get; set; }
        public string? Location { get; set; } = "";
    }
}