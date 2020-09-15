import {Injectable} from '@angular/core';
import {RockPaperScissorsActionInterface} from '../models/rock-paper-scissors-action-interface';
import {ResultTypeInterface} from '../models/resultTypeInterface';
import {WinningPlayerInterface} from '../models/winning-player-interface';
import { ResultTypes } from '../models/resultTypes';

@Injectable()
export class WinningPlayerCalculatorService {

  private computerPointCount = 0;
  private playerPointCount = 0;

  public getCalculatedWinningPlayerPoints(resultType: number): WinningPlayerInterface {
    if (resultType === ResultTypes.player1wins.value) {
        this.playerPointCount = (this.playerPointCount) + (1);
        return this.getPlayerPoints(this.playerPointCount, this.computerPointCount);
    } else if(resultType === ResultTypes.player2wins.value){
        this.computerPointCount = (this.computerPointCount) + (1);
        return this.getPlayerPoints(this.playerPointCount, this.computerPointCount);
    } else if(resultType === ResultTypes.draw.value){
      return this.getPlayerPoints(this.playerPointCount, this.computerPointCount);
    }
  }

  private getPlayerPoints(playerPoints: number, computerPoints: number): WinningPlayerInterface {
    return {
      playerPointCount: playerPoints,
      computerPointCount: computerPoints
    };
  }

}
