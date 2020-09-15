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
    public class PlayerFactoryTests
    {

        private PlayerFactory _factory;
        public PlayerFactoryTests()
        {
            _factory = new PlayerFactory();
        }

        [Fact]
        public void Given_The_Factory_IsPassed_PaperActionType_It_Creates_Player_OfType_Paper()
        {
            PlayerFactory factory = new PlayerFactory();

            GameAction player1Action = GameAction.Paper;

            var player1 = factory.CreatePlayer(player1Action);

            Assert.True(player1.GetType() == typeof(PlayerPaper));
        }

        [Fact]
        public void Given_The_Factory_IsPassed_RockActionType_It_Creates_Player_OfType_Rock()
        {
            PlayerFactory factory = new PlayerFactory();

            GameAction player1Action = GameAction.Rock;

            var player1 = factory.CreatePlayer(player1Action);

            Assert.True(player1.GetType() == typeof(PlayerRock));
        }

        [Fact]
        public void Given_The_Factory_IsPassed_ScissorsActionType_It_Creates_Player_OfType_Scissors()
        {
            PlayerFactory factory = new PlayerFactory();

            GameAction player1Action = GameAction.Scissors;

            var player1 = factory.CreatePlayer(player1Action);

            Assert.True(player1.GetType() == typeof(PlayerScissors));
        }
    }
}
