using Newtonsoft.Json;

namespace Basiccrud.Common
{
    public class GlobalUIdModel
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId{ get; set; }
    }
}
