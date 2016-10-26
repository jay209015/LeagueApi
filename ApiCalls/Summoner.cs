using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueApi.ApiCalls {
    public class Summoner : Base {
        public List<LeagueApi.Models.Summoner> GetSummonerByName(string SummonerNames) {
            var EndPoint = $"/v1.4/summoner/by-name/{SummonerNames}";
            Task<string> Task = SendRequest(EndPoint);
            Task.Wait();
            string stringResponse = Task.Result;

            Dictionary<string, LeagueApi.Models.Summoner> Summoners =  JsonConvert.DeserializeObject<Dictionary<string, LeagueApi.Models.Summoner>>(stringResponse);

            var summonerList = new List<LeagueApi.Models.Summoner>();
            foreach(KeyValuePair<string, LeagueApi.Models.Summoner> entry in Summoners)
            {
               summonerList.Add(entry.Value);
            }

            return summonerList;
        }
    }
}