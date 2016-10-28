import { Component, OnInit, Input } from '@angular/core';
import { Summoner } from '../models/Summoner';
import { SummonerService } from '../services/summoner.service'
import { PlayerStatsSummaryList } from '../models/PlayerStatsSummaryList';

@Component({
  selector: 'summoner-details',
  templateUrl: '/ng-app/views/SummonerDetails/details.html',
  providers: [SummonerService]
})
export class SummonerDetailsComponent {
  @Input()
  summoner: Summoner;
  public details: PlayerStatsSummaryList;

  constructor(private summonerService: SummonerService) { 

  }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails(): void {
    console.log(this.summoner);
    this.summonerService.getSummonerDetails(this.summoner)
      .then(details => this.details = details);
  }
}
