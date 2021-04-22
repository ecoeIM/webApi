using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class ProfileData
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("maxAllowedTemperature")]
        public double MaxAllowedTemperature { get; set; }
        [JsonPropertyName("minAllowedTemperature")]
        public double MinAllowedTemperature { get; set; }
        [JsonPropertyName("maxAllowedCarbonDioxideLevel")]
        public double MaxAllowedCarbonDioxideLevel { get; set; }
        [JsonPropertyName("minAllowedCarbonDioxideLevel")]
        public double MinAllowedCarbonDioxideLevel { get; set; }
        [JsonPropertyName("maxHumidityLevel")]
        public double MaxHumidityLevel { get; set; }
        [JsonPropertyName("minHumidityLevel")]
        public double MinHumidityLevel { get; set; }
        

    }
}