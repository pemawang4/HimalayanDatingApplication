import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Preference } from '../models/preference';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string = "https://localhost:5001/api/User";
  constructor(private _httpClient: HttpClient) { }

  saveUser(user: User): Observable<User> {
    return this._httpClient.post<User>(this.baseUrl + "/saveUser", user);
  }

  userLogin(user: User): Observable<User> {
    return this._httpClient.post<User>(this.baseUrl + "/userLogin", user);
  }

  getUser(id: string): Observable<any> {
    return this._httpClient.get<User>(this.baseUrl + "/getUserById/" + id);
  }

  savePreference(preference: Preference): Observable<any> {
    debugger
    return this._httpClient.post<any>(this.baseUrl + "/savePreference", preference);
  }
}
