using Microsoft.Extensions.Logging;
using RockPaperScissors.Game.Application.Constants;
using RockPaperScissors.Game.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Game.Application.Processor
{
    public class GameProcessor : IGameProcessor
    {
        private readonly ILogger<GameProcessor> _logger;

        public GameProcessor(ILogger<GameProcessor> logger)
        {
            _logger = logger;
        }

        public Response<GameResult> Play(GameModel gameModel)
        {
            try
            {
                Response<GameResult> response;

                GameResult resultData = new GameResult
                {
                    Player1Action = gameModel.Player1.Action().ToString(),
                    Player2Action = gameModel.Player2.Action().ToString()
                };

                if (gameModel.Player1.Action() == gameModel.Player2.Action())
                {
                    resultData.ResultMessage = "Its a Draw!!";
                    resultData.ResultType = GameResultTypes.Draw;
                }

                var winningAction = WinningHand(gameModel.Player1.Action(), gameModel.Player2.Action());

                if (gameModel.Player1.Action() == winningAction)
                {
                    resultData.ResultMessage = "Player 1 wins!!";
                    resultData.ResultType = GameResultTypes.Player1Wins;
                }

                else if (gameModel.Player2.Action() == winningAction)
                {
                    resultData.ResultMessage = "Player 2 wins!!";
                    resultData.ResultType = GameResultTypes.Player2Wins;
                }
                //TO Do Refactor
                if (gameModel.Player1.Action() == gameModel.Player2.Action() || gameModel.Player1.Action() == winningAction || gameModel.Player2.Action() == winningAction)
                {
                    response = new Response<GameResult>()
                    {
                        Data = resultData,
                        Success = false,
                        Message = string.Empty,
                        StatusCode = System.Net.HttpStatusCode.OK
                    };
                    return response;
                }
                else
                {
                    var errorMessage = $"Error-Unknown result!!";
                    _logger.LogError(errorMessage);
                    resultData.ResultMessage = "errorMessage";
                    response = new Response<GameResult>()
                    {
                        Data = resultData,
                        Success = false,
                        Message = errorMessage,
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };
                    return response;
                }
            }
            catch
            {
                throw;
            }

        }

        //TO Do Refactor And Move this to a seperate class of its own
        private GameAction? WinningHand(GameAction player1Action, GameAction player2Action)
        {
            if (player1Action == GameAction.Paper && player2Action == GameAction.Rock)
            {
                return GameAction.Paper;
            }

            if (player1Action == GameAction.Paper && player2Action == GameAction.Scissors)
            {
                return GameAction.Scissors;
            }

            if (player1Action == GameAction.Scissors && player2Action == GameAction.Paper)
            {
                return GameAction.Scissors;
            }

            if (player1Action == GameAction.Scissors && player2Action == GameAction.Rock)
            {
                return GameAction.Rock;
            }

            if (player1Action == GameAction.Rock && player2Action == GameAction.Paper)
            {
                return GameAction.Paper;
            }

            if (player1Action == GameAction.Rock && player2Action == GameAction.Scissors)
            {
                return GameAction.Rock;
            }

            return null;
        }
    }
}
