using RockPaperScissors.Game.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Game.Application.Services
{
    public class RandomGameOptionGeneratorService : IRandomGameOptionGeneratorService
    {
        static Array gameActions = Enum.GetValues(typeof(GameAction));
        public GameAction GetRandomAction()
        {
            Random random = new Random();

            GameAction randomOption = (GameAction)gameActions.GetValue(random.Next(gameActions.Length));

            return randomOption;
        }
    }
}
