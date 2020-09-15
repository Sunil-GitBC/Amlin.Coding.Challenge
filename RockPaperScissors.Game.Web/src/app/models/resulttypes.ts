import {ResultTypeInterface} from './resultTypeInterface';

export class ResultTypes {
  public static readonly draw: ResultTypeInterface = {name: 'Draw', value: 0};
  public static readonly player1wins: ResultTypeInterface = {name: 'Player1Wins', value: 1};
  public static readonly player2wins: ResultTypeInterface = {name: 'Player2Wins', value: 2};
}