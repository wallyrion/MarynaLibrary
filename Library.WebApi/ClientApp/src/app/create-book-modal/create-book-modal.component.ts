import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-create-book-modal',
  templateUrl: './create-book-modal.component.html',
  styleUrls: ['./create-book-modal.component.scss']
})
export class CreateBookModalComponent implements OnInit {

  form: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<CreateBookModalComponent>
    ) { }

  ngOnInit() {
    this.form = this._formBuilder.group({
      author: ['', Validators.required],
      title: ['', Validators.required],
      quantity: ['', Validators.required]
    });
  }

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}
