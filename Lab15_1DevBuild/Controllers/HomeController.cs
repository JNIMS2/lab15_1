using Lab15_1DevBuild.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab15_1DevBuild.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        //get the shuffled new deck of cards
        //this ur works
        //replaced new with a deck id. need to figure out how to pass the New deck id to the draw 5
        public async Task<IActionResult> GetDeck()
        {
            string domain = "https://deckofcardsapi.com";
            string path = "/api/deck/9ol3rpkhq2ne/shuffle/?deck_count=1";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connnection = await client.GetAsync(path);
            Root result = await connnection.Content.ReadAsAsync<Root>();
            return View(result);
        }

        //draw 5 cards from that deck--display names and images inside a view
        //maybe i need to make the root the already deckdraw
        //url works without the .json. so, should i remove it and just put the deck id in key?
        //or do i need the .json to show things? cuz i do that in razor...
        //added the.json back in for now
        public async Task<IActionResult> Drawfive(string deck_id)
        { 
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/9ol3rpkhq2ne/draw/?count=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connnection = await client.GetAsync(path);
            DeckDraw result = await connnection.Content.ReadAsAsync<DeckDraw>();
            return View(result);
        }


        //have a button that draws 5 more cards


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
