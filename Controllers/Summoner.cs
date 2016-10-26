using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LeagueApi.Controllers
{
    public class SummonerController : Controller
    {
        private IMemoryCache memoryCache;
        public SummonerController(IMemoryCache memoryCache) 
        {
            this.memoryCache = memoryCache;
        }
        public PartialViewResult ByName(string name)
        {
            ApiCalls.Summoner Api = new ApiCalls.Summoner(this.memoryCache);
            List<Models.Summoner> Summoners = Api.GetSummonerByName(name);

            return PartialView(Summoners);
        }
    }
}
