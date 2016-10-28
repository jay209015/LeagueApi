import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'playerStatSummaryType'
})

export class PlayerStatSummaryTypePipe implements PipeTransform {
    transform(value: any, type: string[]): any {
        console.log(value);
        console.log(type);
        return value.filter((item) => (type.indexOf(item.playerStatSummaryType) != -1 ));
    }
}