import { Component, OnInit, Inject, Input, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Book, Card } from '../models/book';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-select-book-modal',
  templateUrl: './select-book-modal.component.html',
  styleUrls: ['./select-book-modal.component.scss']
})
export class SelectBookModalComponent implements OnInit {

  searchField = '';
  data: Book[] = [];
  dataSource = new MatTableDataSource<Book>(this.data);
  pageSize = 2;
  displayedColumns = ['author', 'title', 'quantity', 'action']

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  book: Book = <Book>{};

  constructor(
    private dialogRef: MatDialogRef<SelectBookModalComponent>,
    private _service: BookService,
    @Inject(MAT_DIALOG_DATA) data
  ) {
  }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  search() {
    this._service.search(this.searchField).subscribe(res => {
      this.data = res;
      this.dataSource.data = this.data;
    })
  }

  select(book: Book) {
    this.dialogRef.close(this.book);
  }

  close() {
    this.dialogRef.close();
  }

}
