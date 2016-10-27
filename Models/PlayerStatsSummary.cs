using System;

namespace LeagueApi.Models {
    public class PlayerStatsSummary {
        public AggregatedStats aggregatedStats { get; set; }
        public int losses { get; set; }
        public long modifyDate { get; set; }
        public string playerStatSummaryType { get; set; }
        public int wins { get; set; }
        public DateTime getModifyDate()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(modifyDate).ToLocalTime();;
        }
    }
}