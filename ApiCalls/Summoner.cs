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
            var summonerNameList = new List<string>();

            if (SummonerNames.IndexOf(',') != -1) {
                summonerNameList = SummonerNames.Split(',').ToList();
            } else {
                summonerNameList = new List<string>();
                summonerNameList.Add(SummonerNames);
            }
           
            Models.Summoner summoner;
            
            for ( int i = 0; i < summonerNameList.Count; i++ ) {
                if(this.memoryCache.TryGetValue("summoner-" + summonerNameList[i], out summoner)) {
                    summonerList.Add(summoner);
                    summonerNameList.RemoveAt(i);
                } 
            }

            if(summonerNameList.Count > 0) {
                SummonerNames = String.Join(",", summonerNameList);
                var EndPoint = $"/v1.4/summoner/by-name/{SummonerNames}";
                var Task = SendRequest(EndPoint);
                Task.Wait();
                var stringResponse = Task.Result;

                if(stringResponse.Length > 3) {
                    var summoners =  JsonConvert.DeserializeObject<Dictionary<string, LeagueApi.Models.Summoner>>(stringResponse);

                    foreach(KeyValuePair<string, LeagueApi.Models.Summoner> entry in summoners)
                    {
                        this.memoryCache.Set("summoner-" + entry.Key, entry.Value, 
                            new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                        summonerList.Add(entry.Value);
                    }
                }
            }

            return summonerList;
        }
    }
}