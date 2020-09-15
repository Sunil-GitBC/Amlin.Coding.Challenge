import {PlayerInterface} from './playerinterface';

export class PlayerTypes {
  public static readonly human: PlayerInterface = {name: 'Human', value: 0};
  public static readonly computer: PlayerInterface = {name: 'Computer', value: 1};
}