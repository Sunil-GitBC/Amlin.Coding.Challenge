using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RockPaperScissors.Game.Api.Builder;
using RockPaperScissors.Game.Api.Builders.Interface;
using RockPaperScissors.Game.Api.Controllers;
using RockPaperScissors.Game.Api.Models;
using RockPaperScissors.Game.Application.Models;
using RockPaperScissors.Game.Application.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RockPaperScissors.Game.Tests
{
    public class GameControllerTests
    {
        private Mock<ILogger<GameController>> _mockLogger;
        private IGameProcessor _gameProcessor;
        private IModelBuilder<GameModel, PlayRequest> _gameModeBuilder;
        private GameController _gameController;

        public GameControllerTests()
        {
            _mockLogger = new Mock<ILogger<GameController>>();
            _gameProcessor = new GameProcessor(new Mock<ILogger<GameProcessor>>().Object);
            _gameModeBuilder = new GameModelBuilder();
            _gameController = new GameController(_mockLogger.Object, _gameModeBuilder, _gameProcessor);

        }

        [Fact]
        public void Game_User_Selects_Valid_Action_Returns_Ok()
        {
            var playRequest = new PlayRequest
            {
                Player1ChosenAction = Application.Constants.GameAction.Paper
            };
            var response = _gameController.Play(playRequest);
            var result = (((OkObjectResult)response).Value as Response<GameResult>);

            Assert.IsType<OkObjectResult>(response);
            Assert.True(result.Data.Player1Action == Application.Constants.GameAction.Paper.ToString());
        }

        [Fact]
        public void Game_User_Selects_Valid_Player_Type_Returns_Ok()
        {
            var playRequest = new PlayRequest
            {
                Player1Type = Application.Constants.PlayerType.Computer
            };
            var response = _gameController.Play(playRequest);
            var result = (((OkObjectResult)response).Value as Response<GameResult>);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Game_Missing_PlayerType_And_ActionChoice_Throws_BadRequestError()
        {
            var playRequest = new PlayRequest();
            var response = _gameController.Play(playRequest);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        
    }
}
