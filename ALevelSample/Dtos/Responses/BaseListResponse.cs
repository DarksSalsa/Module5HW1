using System.Collections.Generic;
using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class BaseListResponse<T>
        where T : class
    {
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        public SupportDto Support { get; set; }
    }
}
