using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Models
{
    public class GameResult
    {
        public string ResultMessage { get; set; }

        public string Player1Action { get;set; }

        public string Player2Action { get; set; }

        public GameResultTypes ResultType { get; set; }
    }
}
