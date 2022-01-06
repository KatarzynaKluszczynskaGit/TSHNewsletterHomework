using Newtonsoft.Json;
using System.Collections.Generic;

namespace TSHNewsletterHomework.Models
{
    class InboxMessages
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "inbox")]
        public string Inbox { get; set; }
    }

    class Message
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "from")]
        public List<From> From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public List<To> To { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
    }

    class From
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    class To
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

}
