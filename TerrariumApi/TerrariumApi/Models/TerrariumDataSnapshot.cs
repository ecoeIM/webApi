using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class TerrariumDataSnapshot
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
        [JsonPropertyName("carbonDioxideLevel")]
        public double CarbonDioxideLevel { get; set; }
        [JsonPropertyName("humidityLevel")]
        public double HumidityLevel { get; set; }
        [JsonPropertyName("naturalLightLevel")]
        public double NaturalLightLevel { get; set; }
        [JsonPropertyName("isArtificialLightOn")]
        public bool IsArtificialLightOn { get; set; }
    }
}