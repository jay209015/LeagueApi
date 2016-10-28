using System;
using System.Runtime.Serialization;

namespace LeagueApi.Models {
    public class Summoner {
        public long id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate{ get; set; }
        public int summonerLevel { get; set; }
        public DateTime revisionDateTime { get; set; }

        public DateTime getRevisionDate()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(revisionDate);
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            revisionDateTime = getRevisionDate();
        }
    }
}