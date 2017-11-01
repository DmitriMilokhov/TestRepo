using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AdvOrganizer.Model
{
    public class AdvInfoModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Advertiser { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AdvType Type { get; set; }
        public bool IsPaid { get; set; }

        public bool IsMorning
        {
            get
            {
                TimeSpan compareTime = new TimeSpan(14, 0, 0);
                return (Time <= compareTime) ? true : false;
            }
        }
    }
}
