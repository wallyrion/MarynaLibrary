import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private getAllBookUrl = 'api/book/GetAll';
  private createBookUrl = 'api/book/create';
  private removeBookUrl = 'api/book/remove';

  constructor(private _http: HttpClient) { }

  public getAll(): Observable<Book[]> {
    return this._http.get<Book[]>(this.getAllBookUrl);
  }

  public create(book: Book): Observable<number> {
    return this._http.post<number>(this.createBookUrl, book);
  }

  public remove(id: number) {
    return this._http.delete(`this.${this.removeBookUrl}/${id}`);
  }
}
