using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class ScheduledTask
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("repeated")]
        public bool Repeated { get; set; }
        [JsonPropertyName("terrariumDataSnapshot")]
        public TerrariumDataSnapshot TerrariumDataSnapshot { get; set; }
        [JsonPropertyName("terrariumDataSnapshotId")]
        public int TerrariumDataSnapshotId { get; set; }
        [JsonPropertyName("terrariumId")] 
        public int TerrariumId { get; set; }
    }
}