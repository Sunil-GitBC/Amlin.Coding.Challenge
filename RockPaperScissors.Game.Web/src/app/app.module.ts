import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {RockPaperScissorsComponent} from '../app/components/rock-paper-scissors/rock-paper-scissors.component';
import {routingMap} from './app.routes';
import {WinningPlayerCalculatorService} from '../app/services/winning-player-calculator.service';
import {RockPaperScissorsApiService} from '../app/services/rock-paper-scissors-api.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    RockPaperScissorsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    routingMap
  ],
  providers: [
    RockPaperScissorsApiService,
    WinningPlayerCalculatorService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
