using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class TerrariumData
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
        
        [JsonPropertyName("isVentOn")]
        public bool IsVentOn { get; set; }
        
        [JsonPropertyName("temperatureRecords")]
        public List<TemperatureRecord> TemperatureRecords { get; set; }
        
        [JsonPropertyName("carbonDioxideLevelRecords")]
        public List<CarbonDioxideLevelRecord> CarbonDioxideLevelRecords { get; set; }
        
        [JsonPropertyName("humidityLevelRecords")]
        public List<HumidityLevelRecord> HumidityLevelRecords { get; set; }
        
        [JsonPropertyName("naturalLightLevelRecords")]
        public IList<NaturalLightLevelRecord> NaturalLightLevelRecords { get; set; }
        
    }
}