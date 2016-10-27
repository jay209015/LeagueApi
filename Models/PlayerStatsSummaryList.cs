using System.Collections.Generic;

namespace LeagueApi.Models {
    public class PlayerStatsSummaryList {
        public List<PlayerStatsSummary> playerStatSummaries { get; set; }
        public int summonerId { get; set; }
    }
}