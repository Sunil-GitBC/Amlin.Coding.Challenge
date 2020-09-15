using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Entities
{
    public class PlayerPaper : Player
    {
        public override GameAction Action()
        {
            return GameAction.Paper;
        }
    }
}
