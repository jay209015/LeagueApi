using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace LeagueApi.Controllers
{
    public class SummonerController : Controller
    {
        private IMemoryCache memoryCache;

        public SummonerController(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }
        public PartialViewResult ByName(string id)
        {
            var api = new ApiCalls.Summoner(this.memoryCache);
            var Summoners = api.GetSummonerByName(id);

            return PartialView(Summoners);
        }

        public JsonResult Details(int id)
        {
            var api = new ApiCalls.SummonerDetails(this.memoryCache);
            Models.PlayerStatsSummaryList summonerDetails = api.GetSummonerDetails(id);
            var response = JsonConvert.SerializeObject(summonerDetails);

            return Json(response);
        }
    }
}
