import { Component, OnInit } from '@angular/core';
import { Summoner } from './models/summoner';
import { SummonerService } from './services/summoner.service'

@Component({
  selector: 'my-app',
  templateUrl: '/ng-app/views/summoner/summoner.html',
  providers: [SummonerService]
})
export class AppComponent {
  summoners: Summoner[];

  constructor(private summonerService: SummonerService) { }

  ngOnInit(): void {
    this.getSummoners();
  }

  getSummoners(): void {
    this.summonerService.getSummoners()
      .then(summoners => this.summoners = summoners)
      .then(summoners => this.getSummonerDetails(summoners));
  }

  getSummonerDetails(summoner: Summoner[]): void {
    console.log('Get Details:');
    console.log(summoner);
  }
 }
