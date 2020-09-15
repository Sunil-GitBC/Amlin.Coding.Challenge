import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ResponseData } from '../models/Response';
import { GameResult } from '../models/gameresult';
import { PlayRequest } from '../models/playrequest';

@Injectable({
  providedIn: 'root'
})
export class RockPaperScissorsApiService {

  apiUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  public playGame(playRequest: PlayRequest): Observable<ResponseData<GameResult>> { 
    return this.httpClient.post<ResponseData<GameResult>>(`${this.apiUrl}`, playRequest);
  }

}
