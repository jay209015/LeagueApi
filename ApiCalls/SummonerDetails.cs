using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace LeagueApi.ApiCalls {
    public class SummonerDetails : Base {
        private IMemoryCache memoryCache;
        public SummonerDetails(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }

        public LeagueApi.Models.PlayerStatsSummaryList GetSummonerDetails(int summonerId) {
            Models.PlayerStatsSummaryList summonerDetails;

            if(!this.memoryCache.TryGetValue("summoner-details-" + summonerId, out summonerDetails)) {
                var EndPoint = $"/v1.3/stats/by-summoner/{summonerId}/summary";
                var Task = SendRequest(EndPoint);
                Task.Wait();
                var stringResponse = Task.Result;

                summonerDetails =  JsonConvert.DeserializeObject<LeagueApi.Models.PlayerStatsSummaryList>(stringResponse);

                this.memoryCache.Set("summoner-details-" + summonerId, summonerDetails, 
                    new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            } 
        
            return summonerDetails;
        }
    }
}