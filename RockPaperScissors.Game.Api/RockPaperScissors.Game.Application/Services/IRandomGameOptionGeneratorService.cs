using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Services
{
    public interface IRandomGameOptionGeneratorService
    {
        public GameAction GetRandomAction();
    }
}
