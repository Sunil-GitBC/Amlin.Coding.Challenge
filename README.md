 CodingChallenge
RockPaperScissors Game coding challenge

The project is a basic implementation of the Rock Paper Scissors game using Angular version 8 and the UI and ASp.Net Web API
as the server side API

The implementation allows a User to either play select an Action and play with a Computer or also choose
a Computer vs Computer option.
When the Player type is Computer the APi randomly generates an Action to play against the user.
The UI also maintains a score of each Player.

The Solution consists of 4 projects
RockPaperScissors.Game.Api
RockPaperScissors.Game.Application
RockPaperScissors.Game.Tests

And One SPA Angular Project
RockPaperScissors.Game.Web

Please note Swagger is set up for the WebAPI project to test the rest services

 Setup

The SPA uses bootstrap and fontawesome for the UI and other Angular related modules, please Install npm packages

 TO DO 
I would have liked to tidy up the UI and refactored some code.
Though I have written Tests using Moq and xUnit I would have ideally also liked to write BDD tests using Gherkin and SpecFlow.
