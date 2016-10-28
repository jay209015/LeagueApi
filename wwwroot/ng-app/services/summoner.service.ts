import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import { Summoner } from '../models/summoner';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class SummonerService {
    constructor(private http: Http) {}

    private headers = new Headers({'Content-Type': 'application/json'});
    getSummoners(): Promise<Summoner[]> {
        const url = `/summoner/byname/omnimotard,officeladybarb,evauso`;
            return this.http
                .get(url)
                .toPromise()
               .then(this.log)
               .catch(this.handleError);;
    }

    private log(response: Response) {
        let body = response.json() as Summoner[];
        return body || {}
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    } 
}