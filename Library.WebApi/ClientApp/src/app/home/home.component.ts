import { Component, ViewChild, OnInit } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { JournalService } from '../services/journal.service';
import { Journal } from '../models/jornal';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private _service: JournalService) {
  }

  public dataSource = new MatTableDataSource<Journal>();
  pageSize = 20;
  displayedColumns: string[] = ['firstName', 'lastName', 'date'];

  pageChange() {

  }

  ngOnInit(): void {
    console.log('on init');

    this._service.getJournal().subscribe((res: Journal[]) => {
      console.log('res', res);
      this.dataSource.data = res;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });

  }

}
