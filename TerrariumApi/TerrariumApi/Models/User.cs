using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerrariumApi.Models
{
    public class User
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("uid")]
        public string UId { get; set; }
        [JsonPropertyName("terrariumId")]
        public int TerrariumId { get; set; }
    }
}