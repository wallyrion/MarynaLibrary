import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private _http: HttpClient) { }
  private getAllBookUrl = 'api/book/GetAll';

  public GetAll(): Observable<Book[]> {
    return this._http.get<Book[]>(this.getAllBookUrl);
  }
}
