import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { Book } from '../models/book';
import { BookService } from '../services/book.service';
import { CreateBookModalComponent } from '../create-book-modal/create-book-modal.component';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  displayedColumns = ['author', 'title', 'quantity', 'delete']
  pageSize = 5;
  data: Book[] = [];
  dataSource = new MatTableDataSource<Book>(this.data);
  

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private _bookService: BookService,
    private _dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;

    this._bookService.getAll().subscribe((res: Book[]) => {
      this.dataSource.data = res;
      this.data = res;
    })
  }

  createBook() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;

    const dialogRef = this._dialog.open(CreateBookModalComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((book: Book) => {
      this._bookService.create(book)
      .subscribe((id: number) => {
        book.id = id;
        this.data.push(book);
        this.dataSource._updateChangeSubscription();
      });
    });
  }

  remove(book: Book) {
    this._bookService.remove(book.id).subscribe(() => {
      this.data = this.data.filter((element) => element.id !== book.id);
    });
  }

}
