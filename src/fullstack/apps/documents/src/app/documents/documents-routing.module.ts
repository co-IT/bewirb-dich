import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocumentsListComponent } from './documents-list/documents-list.component';

const routes: Routes = [{ path: '', component: DocumentsListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DocumentsRoutingModule {}
