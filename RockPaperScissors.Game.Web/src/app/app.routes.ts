import {RouterModule, Routes} from '@angular/router';
import {RockPaperScissorsComponent} from '../app/components/rock-paper-scissors/rock-paper-scissors.component';

const routes: Routes = [
  {
    path: '',
    component: RockPaperScissorsComponent
  }
];

export const routingMap = RouterModule.forRoot(routes);