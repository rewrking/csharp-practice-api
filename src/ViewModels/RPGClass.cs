using System.Text.Json.Serialization;

namespace tutorial1.ViewModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RPGClass
{
    None,
    Knight,
    Mage,
    Cleric
}
