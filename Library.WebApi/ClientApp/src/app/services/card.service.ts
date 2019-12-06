import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  private getAllUrl = 'api/librarycard';
  private createRecordUrl = 'api/librarycard'
  constructor(private _http: HttpClient) { }

  GetAll(): Observable<Card[]> {
    return this._http.get<Card[]>(this.getAllUrl);
  }

  createRecord(readerId: number, bookId: number) {
    return this._http.post(this.createRecordUrl, {readerId, bookId })
  }
}
