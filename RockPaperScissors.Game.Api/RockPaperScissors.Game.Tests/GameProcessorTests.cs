using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RockPaperScissors.Game.Api.Builder;
using RockPaperScissors.Game.Api.Builders.Interface;
using RockPaperScissors.Game.Api.Controllers;
using RockPaperScissors.Game.Api.Models;
using RockPaperScissors.Game.Application.Constants;
using RockPaperScissors.Game.Application.Entities;
using RockPaperScissors.Game.Application.Models;
using RockPaperScissors.Game.Application.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RockPaperScissors.Game.Tests
{
    public class GameProcessorTests
    {
        private Mock<ILogger<GameProcessor>> _mockLogger;
        private IGameProcessor _gameProcessor;

        public GameProcessorTests()
        {
            _mockLogger = new Mock<ILogger<GameProcessor>>();
            _gameProcessor = new GameProcessor(new Mock<ILogger<GameProcessor>>().Object);
        }

        [Theory]
        [InlineData(GameAction.Rock, GameAction.Rock, GameResultTypes.Draw)]
        [InlineData(GameAction.Rock, GameAction.Paper, GameResultTypes.Player2Wins)]
        [InlineData(GameAction.Rock, GameAction.Scissors, GameResultTypes.Player1Wins)]
        public void Player1_Always_Selects_Rock_Tests(GameAction player1Action, GameAction player2Action, GameResultTypes expectedCondition)
        {
            PlayerFactory factory = new PlayerFactory();

            var player1 = factory.CreatePlayer(player1Action);
            var player2 = factory.CreatePlayer(player2Action);

            var gameModel = new GameModel(player1, player2);
            var result = _gameProcessor.Play(gameModel);

            Assert.True(result.Data.ResultType == expectedCondition);
        }

        [Theory]
        [InlineData(GameAction.Paper, GameAction.Paper, GameResultTypes.Draw)]
        [InlineData(GameAction.Paper, GameAction.Rock, GameResultTypes.Player1Wins)]
        [InlineData(GameAction.Paper, GameAction.Scissors, GameResultTypes.Player2Wins)]
        public void Player1_Always_Selects_Paper_Tests(GameAction player1Action, GameAction player2Action, GameResultTypes expectedCondition)
        {
            PlayerFactory factory = new PlayerFactory();

            var player1 = factory.CreatePlayer(player1Action);
            var player2 = factory.CreatePlayer(player2Action);

            var gameModel = new GameModel(player1, player2);
            var result = _gameProcessor.Play(gameModel);

            Assert.True(result.Data.ResultType == expectedCondition);
        }

        [Theory]
        [InlineData(GameAction.Scissors, GameAction.Scissors, GameResultTypes.Draw)]
        [InlineData(GameAction.Scissors, GameAction.Rock, GameResultTypes.Player2Wins)]
        [InlineData(GameAction.Scissors, GameAction.Paper, GameResultTypes.Player1Wins)]
        public void Player1_Always_Selects_Scissors_Tests(GameAction player1Action, GameAction player2Action, GameResultTypes expectedCondition)
        {
            PlayerFactory factory = new PlayerFactory();

            var player1 = factory.CreatePlayer(player1Action);
            var player2 = factory.CreatePlayer(player2Action);

            var gameModel = new GameModel(player1, player2);
            var result = _gameProcessor.Play(gameModel);

            Assert.True(result.Data.ResultType == expectedCondition);
        }
    }
}
