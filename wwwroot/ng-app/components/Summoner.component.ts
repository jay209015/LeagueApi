import { Component, OnInit } from '@angular/core';
import { Summoner } from '../models/summoner';
import { SummonerService } from '../services/summoner.service'

@Component({
  selector: 'summoners',
  templateUrl: '/ng-app/views/Summoner/summoner.html',
  providers: [SummonerService]
})
export class SummonerComponent {
  summoners: Summoner[];

  constructor(private summonerService: SummonerService) { }

  ngOnInit(): void {
    this.getSummoners();
  }

  getSummoners(): void {
    this.summonerService.getSummoners('omnimotard,officeladybarb,rosslyn568,evauso')
      .then(summoners => this.summoners = summoners);
  }
 }
