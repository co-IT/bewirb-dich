import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocumentsListComponent } from './documents-list/documents-list.component';
import { DocumentsRoutingModule } from './documents-routing.module';

@NgModule({
  declarations: [DocumentsListComponent],
  imports: [CommonModule, DocumentsRoutingModule],
})
export class DocumentsListModule {}
