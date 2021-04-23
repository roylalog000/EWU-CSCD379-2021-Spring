namespace UserGroup.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        [System.Text.Json.Serialization.JsonPropertyName("speakers")]
        public string[]? UserGroupSpeakers { get; set; } 
    }
}