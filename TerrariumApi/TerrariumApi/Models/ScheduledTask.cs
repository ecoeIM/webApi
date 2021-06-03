using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class ScheduledTask
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("toggleLight")]
        public bool ToggleLight { get; set; }
        [JsonPropertyName("toggleVent")]
        public bool ToggleVent { get; set; }
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("terrariumId")]
        public int TerrariumId { get; set; }
    }
}