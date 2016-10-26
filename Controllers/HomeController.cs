using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LeagueApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["BackgroundImage"] = "http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Aatrox_0.jpg";
            ApiCalls.Summoner Api = new ApiCalls.Summoner();
            List<Models.Summoner> Summoners = Api.GetSummonerByName("omnimotard,evauso,officeladybarb");
            return View(Summoners);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
