/// <reference path="../../typings.d.ts" />

// COMMON
import * as moment from 'moment';

export class DateUtils {

    public isInPeriod(date: Date, beginDate: string, endDate: string): boolean {
        return (moment(date).isSame(moment(beginDate), 'day') || moment(date).isAfter(moment(beginDate), 'day')) &&
            (!endDate || (moment(date).isSame(moment(endDate), 'day') || moment(date).isBefore(moment(endDate), 'day')));
        
    }
}
