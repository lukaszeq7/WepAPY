using System.Text.Json.Serialization;

namespace WepAPY.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StudentType
    {
        Talented = 1,
        Worker = 2,
        Idiot = 3
    }
}