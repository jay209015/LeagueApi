import {Pipe, PipeTransform} from '@angular/core';
import { PlayerStatsSummaryList } from '../models/PlayerStatsSummaryList';

@Pipe({
    name: 'playerStatSummaryType'
})

export class PlayerStatSummaryTypePipe implements PipeTransform {
    transform(playerStatsSummaryList: any, type: string[]): any {
        return playerStatsSummaryList.filter((item) => (type.indexOf(item.playerStatSummaryType) != -1 ));
    }
}