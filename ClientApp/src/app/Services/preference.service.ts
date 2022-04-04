import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Preference } from '../models/preference';

@Injectable({
  providedIn: 'root'
})
export class PreferenceService {
  private baseUrl: string = "https://localhost:5001/api/Preference";
  constructor(private _httpClient: HttpClient) { }

  savePreference(preference: Preference): Observable<any> {
    return this._httpClient.post<Preference>(this.baseUrl + "/savePreference", preference);
  }

}
