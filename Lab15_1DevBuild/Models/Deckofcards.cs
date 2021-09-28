using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15_1DevBuild.Models
{
    //renamed deckshuffled to Root
    public class Root
    {
        public bool success { get; set; }
        public string deck_id { get; set; }

        public int remaining { get; set; }
        public bool shuffled { get; set; }
    }

    //the deck for this: 
    
//"success": true,
//"deck_id": "30l9s5i22t2s",
//"remaining": 52,
//"shuffled": true


    public class Card
    {
        public string code { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }

    public class DeckDraw
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public List<Card> cards { get; set; }

        public int remaining { get; set; }
        public bool shuffled { get; set; }
    }
}
