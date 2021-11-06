import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UserDTO } from '../shared/interfaces/user.interface';
import { AnswerDTO } from '../shared/interfaces/answer.interface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AnswerService {
  host = environment.url + '/answer';

  constructor(private http: HttpClient) {
  }

  public getByTaskId(taskId: number, take: number, skip: number) {
    let params = new HttpParams();
    params = params.append('taskId', taskId.toString());
    params = params.append('take', take.toString());
    params = params.append('skip', skip.toString());

    return this.http.get<UserDTO>(`${this.host}/get-by-task-id`, { params });
  }

  public getLastAnswer(userId: number): Observable<AnswerDTO[]> {
    return this.http.get<AnswerDTO[]>(`${this.host}/get-last/${userId}`);
  }

  public createAnswers(answers: AnswerDTO[]) {
    return this.http.post(`${this.host}/create-answers`, answers);
  }

  public validateLast(userId: number): Observable<AnswerDTO[]> {
    return this.http.get<AnswerDTO[]>(`${this.host}/validate-last/${userId}`);
  }
}
