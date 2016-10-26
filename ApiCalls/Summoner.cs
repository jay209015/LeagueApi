using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;


namespace LeagueApi.ApiCalls {
    public class Summoner : Base {
        private IMemoryCache memoryCache;
        public Summoner(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }

        public List<LeagueApi.Models.Summoner> GetSummonerByName(string SummonerNames) {
            var summonerList = new List<LeagueApi.Models.Summoner>();
            List<string> summoners = SummonerNames.Split(',').ToList();
            Models.Summoner summoner;
            
            for ( int i = 0; i < summoners.Count; i++ ) {
                if(this.memoryCache.TryGetValue("summoner-" + summoners[i], out summoner)) {
                    summonerList.Add(summoner);
                    summoners.RemoveAt(i);
                } 
            }

            SummonerNames = String.Join(",", summoners);

            if(SummonerNames.Length > 3) {
                var EndPoint = $"/v1.4/summoner/by-name/{SummonerNames}";
                Task<string> Task = SendRequest(EndPoint);
                Task.Wait();
                string stringResponse = Task.Result;

                Dictionary<string, LeagueApi.Models.Summoner> Summoners =  JsonConvert.DeserializeObject<Dictionary<string, LeagueApi.Models.Summoner>>(stringResponse);

                foreach(KeyValuePair<string, LeagueApi.Models.Summoner> entry in Summoners)
                {
                    this.memoryCache.Set("summoner-" + entry.Key, entry.Value, 
                        new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                    summonerList.Add(entry.Value);
                }
            }

            return summonerList;
        }
    }
}