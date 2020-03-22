import { Component, OnInit, Inject, Input, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Book, Card, Reader } from '../models/book';
import { BookService } from '../services/book.service';
import { ReaderService } from '../services/reader.service';

@Component({
  selector: 'app-select-reader-modal',
  templateUrl: './select-reader-modal.component.html',
  styleUrls: ['./select-reader-modal.component.scss']
})
export class SelectReaderModalComponent implements OnInit {

  searchField = '';
  data: Reader[] = [];
  dataSource = new MatTableDataSource<Reader>(this.data);
  pageSize = 3;
  displayedColumns = ['firstName', 'lastName', 'phone', 'action']

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  reader: Reader = <Reader>{};

  constructor(
    private dialogRef: MatDialogRef<SelectReaderModalComponent>,
    private _service: ReaderService  ) {
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

  select(reader: Reader) {
    this.dialogRef.close(reader);
  }

  close() {
    this.dialogRef.close();
  }

}
