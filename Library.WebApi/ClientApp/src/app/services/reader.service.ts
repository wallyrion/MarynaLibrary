import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reader } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class ReaderService {
  private getAllReadersUrl = 'api/reader/GetAll';
  private createReaderUrl = 'api/reader/create';
  private removeReaderUrl = 'api/reader/remove';
  private editReaderUrl = 'api/reader/edit';
  private searchReaderUrl = 'api/reader/search';

  constructor(private _http: HttpClient) { }

  public getAll(): Observable<Reader[]> {
    return this._http.get<Reader[]>(this.getAllReadersUrl);
  }

  public create(book: Reader): Observable<number> {
    return this._http.post<number>(this.createReaderUrl, book);
  }

  public remove(id: number) {
    return this._http.delete(`${this.removeReaderUrl}/${id}`);
  }

  public edit(book: Reader) {
    return this._http.put(this.editReaderUrl, book);
  }

  public search(value: string): Observable<Reader[]> {
    return this._http.get<Reader[]>(this.searchReaderUrl, { params: { value } });
  }
}
