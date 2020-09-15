using RockPaperScissors.Game.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Models
{
    public class GameModel
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public GameModel (Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
