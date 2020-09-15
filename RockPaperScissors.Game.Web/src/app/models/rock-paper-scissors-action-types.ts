import {RockPaperScissorsActionInterface} from './rock-paper-scissors-action-interface';

export class RockPaperScissorsActionTypes {
  public static readonly rockItemType: RockPaperScissorsActionInterface = {name: 'Rock', value: 0};
  public static readonly paperItemType: RockPaperScissorsActionInterface = {name: 'Paper', value: 1};
  public static readonly scissorsItemType: RockPaperScissorsActionInterface = {name: 'Scissors', value: 2};

}