import {RockPaperScissorsActionInterface} from './rock-paper-scissors-action-interface';

export interface RockPaperScissorsGameInterface {
  computerPlayerSelection?: string;
  playerSelection?: string;
  gameResult?: string;
  computerScore?: number;
  playerScore?: number;
}
