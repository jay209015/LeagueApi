import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Summoner } from '../models/Summoner';
import { PlayerStatsSummaryList } from '../models/PlayerStatsSummaryList';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class SummonerService {
    constructor(private http: Http) {}

    private headers = new Headers({'Content-Type': 'application/json'});
    getSummoners(summoners: string): Promise<Summoner[]> {
        var url = '/summoner/byname';
        return this.http
            .get(url + '/' + summoners)
            .toPromise()
            .then(this.summonerResponse)
            .catch(this.handleError);
    }

    getSummonerDetails(summoner: Summoner): Promise<PlayerStatsSummaryList> {
        var url = '/summoner/details';
        return this.http
            .get(url + '/' + summoner.id)
            .toPromise()
            .then(this.summonerDetailsResponse)
            .catch(this.handleError);
    }

    private summonerResponse(response: Response) {
        let body = response.json() as Summoner[];
        return body || {}
    }

    private summonerDetailsResponse(response: Response) {
        let body = response.json() as PlayerStatsSummaryList;
        console.log(body);
        return body || {}
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    } 
}