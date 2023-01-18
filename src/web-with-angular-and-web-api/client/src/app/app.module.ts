import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ErstelleDokumentModal } from './erstelle-dokument/erstelle-dokument-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    ErstelleDokumentModal
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
