import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentsService } from '../documents.service';
import { Document } from '../models/document';

@Component({
  selector: 'fullstack-documents',
  templateUrl: './documents-list.component.html',
  styleUrls: ['./documents-list.component.scss'],
})
export class DocumentsListComponent {
  documents$: Observable<Document[]>;

  constructor(private documentsService: DocumentsService) {
    this.documents$ = this.documentsService.all();
  }
}
