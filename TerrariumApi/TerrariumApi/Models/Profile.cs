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
        [JsonPropertyName("profileDataDescription")]
        public string ProfileDataDescription { get; set; }
        [JsonPropertyName("profileData")]
        public ProfileData ProfileData { get; set; }
        [JsonPropertyName("profileDataId")]
        public int ProfileDataId { get; set; }
    }
}