using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.Bases
{
    internal class BaseEquipment
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}