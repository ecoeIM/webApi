using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class Terrarium
    {
        [Key]
        [JsonPropertyName("terrariumId")]
        public int TerrariumId { get; set; }
        [Required]
        [JsonPropertyName("terrariumName")]
        public string TerrariumName { get; set; }
        [JsonPropertyName("animalName")]
        public string AnimalName { get; set; }
        [JsonPropertyName("scheduledTaskList")]
        public List<ScheduledTask> ScheduledTaskList { get; set; }
        [JsonPropertyName("terrariumData")]
        public TerrariumData TerrariumData { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}