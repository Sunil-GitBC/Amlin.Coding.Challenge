using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Game.Application.Constants;

namespace RockPaperScissors.Game.Api.Models
{
    public class PlayRequest
    {
        public PlayerType? Player1Type { get; set; }

        public GameAction? Player1ChosenAction { get; set; }
    }
}
