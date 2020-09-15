using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Entities
{
    public abstract class Player
    {
        public PlayerType PlayerType { get; set; }

        public abstract GameAction Action();
    }
}
