using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockPaperScissors.Game.Api.Builders.Interface;
using RockPaperScissors.Game.Api.Models;
using RockPaperScissors.Game.Application.Models;
using RockPaperScissors.Game.Application.Processor;

namespace RockPaperScissors.Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameProcessor _gameProcessor;
        private IModelBuilder<GameModel, PlayRequest> _gameModeBuilder;
        public GameController(ILogger<GameController> logger,
            IModelBuilder<GameModel, PlayRequest> modelBuilder,
            IGameProcessor gameProcessor
           )
        {
            _logger = logger;
            _gameProcessor = gameProcessor;
            _gameModeBuilder = modelBuilder;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<GameResult>), (int)HttpStatusCode.OK)]
        [Route("play")]
        public IActionResult Play([FromBody] PlayRequest playRequestModel)
        {
            try
            {
                if (playRequestModel.Player1Type == null && playRequestModel.Player1ChosenAction == null)
                {
                    return BadRequest("No player or action has been chosen!");
                }

                var gameModel = _gameModeBuilder.CreateFrom(playRequestModel);
                var response = _gameProcessor.Play(gameModel);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Ok(response);
                    case HttpStatusCode.NotFound:
                        return NotFound();
                    case HttpStatusCode.BadRequest:
                        return BadRequest(response.Message);
                    default:
                        return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error playing game: {ex.ToString()}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
