using RockPaperScissors.Game.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Processor
{
    public interface IGameProcessor
    {
        public Response<GameResult> Play(GameModel gameModel);
    }
}
