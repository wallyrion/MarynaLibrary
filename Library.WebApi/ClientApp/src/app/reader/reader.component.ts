import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { Book, Reader } from '../models/book';
import { BookService } from '../services/book.service';
import { CreateBookModalComponent } from '../create-book-modal/create-book-modal.component';
import { ReaderService } from '../services/reader.service';
import { CreateReaderModalComponent } from '../create-reader-modal/create-reader-modal.component';

@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.scss']
})
export class ReaderComponent implements OnInit {
  displayedColumns = ['firstName', 'lastName', 'phone']
  pageSize = 5;
  data: Reader[] = [];
  dataSource = new MatTableDataSource<Reader>(this.data);

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private _readerService: ReaderService,
    private _dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

    this._readerService.getAll().subscribe((res: Reader[]) => {
      this.dataSource.data = res;
      this.data = res;
    });
  }

  createReader() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    const dialogRef = this._dialog.open(CreateReaderModalComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((reader: Reader) => {
      this._readerService.create(reader)
        .subscribe((id: number) => {
          reader.id = id;
          this.data.push(reader);
          this.dataSource._updateChangeSubscription();
        });
    });
  }

  remove(reader: Reader) {
    this._readerService.remove(reader.id).subscribe(() => {
      const index = this.dataSource.data.findIndex((b => b.id === reader.id));
      this.dataSource.data.splice(index, 1);
      this.dataSource._updateChangeSubscription();
    });
  }

  edit(reader: Reader) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.data = { reader: reader };
    const dialogRef = this._dialog.open(CreateReaderModalComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((resReader: Reader) => {
      resReader.id = reader.id;
      this._readerService.edit(resReader)
        .subscribe(() => {
          reader.firstName = resReader.firstName;
          reader.lastName = resReader.lastName;
          reader.phone = resReader.phone;
          this.dataSource._updateChangeSubscription();
        });
    });
  }

}
