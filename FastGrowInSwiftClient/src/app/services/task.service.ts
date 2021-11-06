import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UserDTO } from '../shared/interfaces/user.interface';
import { AnswerDTO } from '../shared/interfaces/answer.interface';
import { TaskDTO, TitleDTO, TypeDTO } from '../shared/interfaces/task.interface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TaskService {
  host = environment.url + '/task';

  constructor(private http: HttpClient) {
  }

  public getByTitleId(titleId: number, take: number, skip: number): Observable<TaskDTO[]> {
    return this.http.get<TaskDTO[]>(`${this.host}/get-by-title-id/${titleId}/${take}/${skip}`);
  }

  public getAllTitles(): Observable<TitleDTO[]> {
    return this.http.get<TitleDTO[]>(`${this.host}/get-all-titles`);
  }

  public getAllTypes() {
    return this.http.get(`${this.host}/get-all-types`);
  }

  public createTask(task: TaskDTO) {
    return this.http.post(`${this.host}/create-task`, task);
  }

  public createTitle(title: TitleDTO) {
    return this.http.post(`${this.host}/create-title`, title);
  }

  public createType(type: TypeDTO) {
    return this.http.post(`${this.host}/create-type`, type);
  }
}
