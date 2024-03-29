import './rxjs-extensions';
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';
import { AppComponent }  from './components/App.component';
import { SummonerComponent }  from './components/Summoner.component';
import { SummonerDetailsComponent }  from './components/SummonerDetails.component';
import { SummonerService }  from './services/summoner.service';
import { Summoner }  from './models/summoner';
import { PlayerStatSummaryTypePipe } from './pipes/PlayerStatSummaryType.pipe'

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
  ],
  declarations: [
    AppComponent,
    SummonerComponent,
    SummonerDetailsComponent,
    PlayerStatSummaryTypePipe
  ],
  providers: [ SummonerService ],
  bootstrap: [ 
    AppComponent
  ]
})
export class AppModule { }
