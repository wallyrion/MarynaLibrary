import { Component, ViewChild, OnInit } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { CardService } from '../services/card.service';
import { Card, Book, Reader } from '../models/book';
import { SelectBookModalComponent } from '../select-book-modal/select-book-modal.component';
import { SelectReaderModalComponent } from '../select-reader-modal/select-reader-modal.component';

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
    
    let newRecord = <Card>{};
    dialogRefBookModal.afterClosed().subscribe((book: Book) => {
      newRecord.bookId = book.id;
      newRecord.author = book.author;
      newRecord.title = book.title;
      const dialogRefReaderModal = this._dialog.open(SelectReaderModalComponent, dialogConfig);
    
      dialogRefReaderModal.afterClosed().subscribe((reader: Reader) => {
      newRecord.firstName = reader.firstName;
      newRecord.lastName = reader.lastName;
      newRecord.phone = reader.phone;
      newRecord.givenDate = new Date();
      
 
      this._service.createRecord(newRecord.readerId, newRecord.bookId).subscribe((id: number) => {
        newRecord.id = id;
        this.data.unshift(newRecord);
        this.dataSource._updateChangeSubscription();
      })
    });
  });
}

  returnBook(record: Card) {
    this._service.returnBook(record.bookId).subscribe(() => {
      record.returnDate = new Date();
    })
  }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    this._service.GetAll().subscribe((res: Card[]) => {
      this.dataSource.data = res;
    });

  }

}
