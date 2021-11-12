import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserDTO } from '../shared/interfaces/user.interface';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AccountService {
  loggedIn = false;
  userChanged = new Subject<number>();
  userId = 1;
  userName = '';
  host = environment.url + '/account';

  constructor(private http: HttpClient) {
  }

  public getAccount(userId: number) {
    return this.http.get<UserDTO>(`${this.host}/get-by-id/${userId}`);
  }

  public registerUser(parameters: UserDTO): Observable<number> {
    return this.http.post<number>(`${this.host}/register`, parameters);
  }

  public login(user: UserDTO): Observable<number>{
    return this.http.post<number>(`${this.host}/login`, user);
  }
}
