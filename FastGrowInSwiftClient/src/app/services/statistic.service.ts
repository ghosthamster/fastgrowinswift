import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Statistic } from '../shared/interfaces/statistic.inerface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StatisticService {
  host = environment.url + '/Answer/get-statistics';

  constructor(private http: HttpClient) {
  }

  public getStatistic(userId): Observable<Statistic[]> {
    return this.http.get<Statistic[]>(`${this.host}/${userId}`);
  }
}
