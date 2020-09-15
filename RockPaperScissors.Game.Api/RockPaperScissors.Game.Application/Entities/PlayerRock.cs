using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Entities
{
    public class PlayerRock : Player
    {
        public override GameAction Action()
        {
            return GameAction.Rock;
        }
    }
}
