using System.Text.Json.Serialization;

namespace Task3
{
    class Item
    {
        [JsonPropertyName("outage_id")]
        public string outageId { get; set; }
        [JsonPropertyName("outage_start")]
        public DateTime outageStart { get; set; }
        [JsonPropertyName("outage_end")]
        public DateTime outageEnd { get; set; }
        [JsonPropertyName("affected_areas")]
        public List<AffectedArea>? affectedAreas { get; set; }
        [JsonPropertyName("outage_status")]
        public string outageStatus { get; set; }
        [JsonPropertyName("created_by")]
        public string createdBy { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime createdAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime uupdatedAt { get; set; }

    }
}
