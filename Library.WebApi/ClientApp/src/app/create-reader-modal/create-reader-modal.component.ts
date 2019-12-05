import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Reader } from '../models/book';

@Component({
  selector: 'app-create-reader-modal',
  templateUrl: './create-reader-modal.component.html',
  styleUrls: ['./create-reader-modal.component.scss']
})
export class CreateReaderModalComponent implements OnInit {

  reader: Reader = <Reader>{};

  form: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<CreateReaderModalComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    this.reader = data && data.reader || {};
  }

  ngOnInit() {
    this.form = this._formBuilder.group({
      firstName: [this.reader.firstName || '', Validators.required],
      lastName: [this.reader.lastName || '', Validators.required],
      phone: [this.reader.phone || '', Validators.required]
    });
  }

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}
