using Newtonsoft.Json;

namespace Jrpg.Runtime.DataClasses.Bases
{
    internal class BaseData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}