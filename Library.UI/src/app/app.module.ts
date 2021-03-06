import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
import { SelectBookModalComponent } from './select-book-modal/select-book-modal.component';
import { SelectReaderModalComponent } from './select-reader-modal/select-reader-modal.component';
import { APIInterceptor } from './interceptors/http-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BookComponent,
    CreateBookModalComponent,
    CreateReaderModalComponent,
    ReaderComponent,
    SelectBookModalComponent,
    SelectReaderModalComponent
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
    SelectReaderModalComponent,
    SelectBookModalComponent,
    CreateBookModalComponent,
    CreateReaderModalComponent
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: APIInterceptor,
    multi: true,
  }
],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
