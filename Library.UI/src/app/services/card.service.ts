import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private getAllUrl = 'api/librarycard/GetAllRecords';
  private createRecordUrl = 'api/librarycard/createRecord'
  private returnBookUrl = 'api/librarycard/return'

  constructor(private _http: HttpClient) { }

  GetAll(): Observable<Card[]> {
    return this._http.get<Card[]>(this.getAllUrl);
  }

  returnBook(cardId: number) {
    return this._http.put(`${this.returnBookUrl}/${cardId}`, {});
  }
  createRecord(readerId: number, bookId: number) {
    return this._http.post(this.createRecordUrl, {readerId, bookId })
  }
}
