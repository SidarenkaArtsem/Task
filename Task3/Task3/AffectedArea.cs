using System.Text.Json.Serialization;

namespace Task3
{
    internal class AffectedArea
    {
        [JsonPropertyName("area_id")]
        public string areaId { get; set; }
        [JsonPropertyName("area_name")]
        public string areaName { get; set; }
        [JsonPropertyName("total_customers")]
        public long totalCustomers { get; set; }
        [JsonPropertyName("affected_customers")]
        public long affectedCustomers { get; set; }
        [JsonPropertyName("estimated_recovery_time")]
        public DateTime estimatedRecoveryTime { get; set; }
        public string reason { get; set; }
    }
}
