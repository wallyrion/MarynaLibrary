import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Journal } from '../models/jornal';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JournalService {

  private getJournalUrl = 'api/journal';

constructor(private _http: HttpClient) { }

  getJournal(): Observable<Journal[]> {
    return this._http.get<Journal[]>(this.getJournalUrl);
  }
}
