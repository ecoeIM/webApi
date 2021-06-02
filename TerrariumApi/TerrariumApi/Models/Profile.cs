using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class Profile
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("profileName")]
        public string ProfileName { get; set; }
        [JsonPropertyName("minTemp")]
        public int MinTemp { get; set; }
        [JsonPropertyName("maxTemp")]
        public int MaxTemp { get; set; }
        [JsonPropertyName("minHumid")]
        public int MinHumid { get; set; }
        [JsonPropertyName("maxHumid")]
        public int MaxHumid { get; set; }
        [JsonPropertyName("minCo2")]
        public int MinCo2 { get; set; }
        [JsonPropertyName("maxCo2")]
        public int MaxCo2 { get; set; }
        [JsonPropertyName("minLight")]
        public int MinLight { get; set; }
        [JsonPropertyName("maxLight")]
        public int MaxLight { get; set; }
        [JsonPropertyName("terrariumId")]
        public int TerrariumId { get; set; }

     
    }
}