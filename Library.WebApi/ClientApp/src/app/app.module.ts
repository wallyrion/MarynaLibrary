import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModulesModule } from './material-modules/material-modules.module';
import { BookComponent } from './book/book.component';
import { AppRoutingModule } from './app-routing.module';
import { CreateBookModalComponent } from './create-book-modal/create-book-modal.component';
import { CreateReaderModalComponent } from './create-reader-modal/create-reader-modal.component';
import { ReaderComponent } from './reader/reader.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BookComponent,
    CreateBookModalComponent,
    CreateReaderModalComponent,
    ReaderComponent
  ],
  imports: [
    ReactiveFormsModule,
    MaterialModulesModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  entryComponents: [
    CreateBookModalComponent,
    CreateReaderModalComponent
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
