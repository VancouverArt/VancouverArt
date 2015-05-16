using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace vancouverart//ZUMOAPPNAME.DataModel
{
    public class art_items
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "long")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
    }
}
