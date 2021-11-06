import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UserDTO } from '../shared/interfaces/user.interface';
import { AnswerDTO } from '../shared/interfaces/answer.interface';
import { TaskDTO, TitleDTO, TypeDTO } from '../shared/interfaces/task.interface';
import { ProgressDTO } from '../shared/interfaces/progress.interface';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
  export class ProgressService {
  host = environment.url + '/progress';

  constructor(private http: HttpClient) {
  }

  public getByUserTaskId(userId: number, taskId: number): Observable<ProgressDTO> {
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    params = params.append('taskId', taskId.toString());

    return this.http.get<ProgressDTO>(`${this.host}/get-by-user-task`, { params });
  }

  public getByUserId(userId: number) {
    let params = new HttpParams();
    params = params.append('userId', userId.toString());

    return this.http.get(`${this.host}/get-by-user`, { params });
  }

  public addProgress(progress: ProgressDTO) {
    return this.http.post(`${this.host}/add-progress`, progress);
  }

  public updateProgress(progress: ProgressDTO) {
    return this.http.put(`${this.host}/update-progress`, progress);
  }

  public deleteProgress(userId: number, taskId: number) {
    return this.http.delete(`${this.host}/delete-progress/${userId}/${taskId}`);
  }
}
