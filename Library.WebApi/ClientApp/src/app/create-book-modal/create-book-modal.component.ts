import { Component, OnInit, Inject, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BookService } from '../services/book.service';
import { Book } from '../models/book';

@Component({
  selector: 'app-create-book-modal',
  templateUrl: './create-book-modal.component.html',
  styleUrls: ['./create-book-modal.component.scss']
})
export class CreateBookModalComponent implements OnInit {

  book: Book = <Book>{};
  isEdit: boolean = false;
  form: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<CreateBookModalComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    this.book = data.book || {};
    this.isEdit = data.book;
  }

  get title(): string {
    return this.isEdit ? 'Edit book' : 'Create book';
  }

  ngOnInit() {
    this.form = this._formBuilder.group({
      author: [this.book.author || '', Validators.required],
      title: [this.book.title || '', Validators.required],
      quantity: [this.book.quantity || '', Validators.required]
    });
  }

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}
