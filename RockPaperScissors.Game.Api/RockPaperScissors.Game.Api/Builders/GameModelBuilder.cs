using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Game.Api.Builders.Interface;
using RockPaperScissors.Game.Api.Models;
using RockPaperScissors.Game.Application.Constants;
using RockPaperScissors.Game.Application.Entities;
using RockPaperScissors.Game.Application.Models;
using RockPaperScissors.Game.Application.Services;

namespace RockPaperScissors.Game.Api.Builder
{
    public class GameModelBuilder : IModelBuilder<GameModel, PlayRequest>
    {
        public GameModel CreateFrom(PlayRequest playRequest)
        {
            try
            {
                Player player1 = GetPlayer1(playRequest);

                Player computerPlayer = GetComputerPlayer();

                GameModel gameModel = new GameModel(player1, computerPlayer);

                return gameModel;
            }
            catch
            {
                throw;
            }
        }

        private Player GetPlayer1(PlayRequest playRequest)
        {
            try
            {
                PlayerFactory factory = new PlayerFactory();

                Player player1 = null;

                if (playRequest.Player1Type == PlayerType.Computer)
                {
                    player1 = GetComputerPlayer();
                }
                else
                {
                    player1 = factory.CreatePlayer(playRequest.Player1ChosenAction.Value);
                    if (player1 == null)
                    {
                        throw new Exception();
                    }
                    player1.PlayerType = PlayerType.Human;
                }

                return player1;
            }
            catch
            {
                throw;
            }
        }

        private Player GetComputerPlayer()
        {
            var randomAction = new RandomGameOptionGeneratorService().GetRandomAction();
            PlayerFactory factory = new PlayerFactory();
            var computerPlayer = factory.CreatePlayer(randomAction);
            computerPlayer.PlayerType = PlayerType.Computer;
            return computerPlayer;
        }
    }
}
