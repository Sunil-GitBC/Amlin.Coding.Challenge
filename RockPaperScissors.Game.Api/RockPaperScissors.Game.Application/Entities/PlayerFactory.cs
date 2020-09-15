using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Entities
{
    public class PlayerFactory
    {
        public Player CreatePlayer(GameAction action)
        {
            Player player = null;

            switch (action)
            {
                case GameAction.Rock:
                    player = new PlayerRock();
                    break;
                case GameAction.Paper:
                    player = new PlayerPaper();
                    break;
                case GameAction.Scissors:
                    player = new PlayerScissors();
                    break;
            }

            return player;
        }
    }
}
