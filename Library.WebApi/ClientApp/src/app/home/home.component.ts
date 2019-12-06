import { Component, ViewChild, OnInit } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { CardService } from '../services/card.service';
import { Card, Book } from '../models/book';
import { SelectBookModalComponent } from '../select-book-modal/select-book-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

})
export class HomeComponent implements OnInit {

  data: Card[] = []
  dataSource = new MatTableDataSource<Card>(this.data);
  pageSize = 2;
  displayedColumns: string[] = ['firstName', 'lastName', 'phone', 'author', 'title', 'givenDate', 'returnDate', 'action'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private _service: CardService, private _dialog: MatDialog) {
  }

  addRecord() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.data = {};
    const dialogRefBookModal = this._dialog.open(SelectBookModalComponent, dialogConfig);
    
    const newRecord = <Card>{};
    dialogRefBookModal.afterClosed().subscribe((book: Book) => {
      newRecord.bookId = book.id;

      //const dialogRefReaderModal = this._dialog.open(SelectBookModalComponent, dialogConfig);
    
      //const newRecord = <Card>{};
      //dialogRefBookModal.afterClosed().subscribe((book: Book) => {
        //newRecord.bookId = book.id;

    });
  }

  returnBook(record: Card) {

  }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    debugger;
    this._service.GetAll().subscribe((res: Card[]) => {
      this.dataSource.data = res;
    });

  }

}
