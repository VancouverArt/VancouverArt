using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Geolocation;

namespace VancouverArtApp//ZUMOAPPNAME.DataModel
{
    public class art_items
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "long")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        public Geopoint Location
        {
            get
            {
                return new Geopoint(new BasicGeoposition {Latitude = this.Latitude, Longitude = this.Longitude });
            }
        }
    }
}
