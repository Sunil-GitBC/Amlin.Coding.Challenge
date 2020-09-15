import {Component, OnInit} from '@angular/core';
import {RockPaperScissorsActionInterface} from '../../models/rock-paper-scissors-action-interface';
import {RockPaperScissorsGameInterface} from '../../models/rock-paper-scissors-game-interface';
import {RockPaperScissorsActionTypes} from '../../models/rock-paper-scissors-action-types';
import {PlayerInterface} from '../../models/playerinterface';
import {PlayerTypes} from '../../models/playertypes';

import {WinningPlayerInterface} from '../../models/winning-player-interface';

import {WinningPlayerCalculatorService} from '../../services/winning-player-calculator.service';
import {RockPaperScissorsApiService} from '../../services/rock-paper-scissors-api.service';
import { PlayRequest } from 'src/app/models/playrequest';
import { ResponseData } from 'src/app/models/Response';
import { GameResult } from 'src/app/models/gameresult';

@Component({
  selector: 'app-rock-paper-scissors',
  templateUrl: './rock-paper-scissors.component.html'
})
export class RockPaperScissorsComponent implements OnInit {
  player1IsHuman = false;
  public rockPaperScissorsGameModel: RockPaperScissorsGameInterface;
  public playerSelectionOptions: Array<RockPaperScissorsActionInterface>;
  public playerTypes: Array<PlayerInterface>;


  constructor(private rockPaperScissorsApiService: RockPaperScissorsApiService,
              private winningPlayerCalculatorService: WinningPlayerCalculatorService,
              ) {
  }

  ngOnInit() {
    this.player1IsHuman = false;

    this.playerSelectionOptions = [
      RockPaperScissorsActionTypes.rockItemType,
      RockPaperScissorsActionTypes.paperItemType,
      RockPaperScissorsActionTypes.scissorsItemType
    ];

    this.playerTypes = [
      PlayerTypes.human,
      PlayerTypes.computer,
    ];
  }

  public playerSelectionEvent(playerSelection: RockPaperScissorsActionInterface): void {
    this.resetSelection();
    const playRequest: PlayRequest = {
      Player1ChosenAction: playerSelection.value,
    };

    this.setRockPaperScissorsGameModel(playRequest);
  }

  public playerSelectionTypeEvent(playerSelectionType: PlayerInterface): void {
    this.resetSelection();
    const playRequest: PlayRequest = {
      Player1Type: playerSelectionType.value,
    };

    if(playerSelectionType.value === PlayerTypes.computer.value){
      this.player1IsHuman = false;
      this.setRockPaperScissorsGameModel(playRequest);
    } else{
      this.player1IsHuman = true;
    }
  }

  private setRockPaperScissorsGameModel(playRequest: PlayRequest): void { 
    this.rockPaperScissorsApiService.playGame(playRequest).subscribe((result: ResponseData<GameResult>) => {
      const winningPlayer: WinningPlayerInterface = this.winningPlayerCalculatorService
      .getCalculatedWinningPlayerPoints(result.data.resultType);

      this.rockPaperScissorsGameModel = {
      computerPlayerSelection: result.data.player2Action,
      playerSelection: result.data.player1Action,
      gameResult: result.data.resultMessage,
      playerScore: winningPlayer.playerPointCount,
      computerScore: winningPlayer.computerPointCount
    };

    }, error => {

    });


  }

  private resetSelection(){
    if(this.rockPaperScissorsGameModel == null){
      this.rockPaperScissorsGameModel = {
        computerPlayerSelection: null,
        playerSelection: null
      };
    } else{
      this.rockPaperScissorsGameModel.computerPlayerSelection = null;
      this.rockPaperScissorsGameModel.playerSelection = null;
    }
  }

}
