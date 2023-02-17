import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { DocumentsService } from '../documents.service';
import { Document } from '../models/document';

@Component({
  selector: 'fullstack-documents',
  templateUrl: './documents-list.component.html',
  styleUrls: ['./documents-list.component.scss'],
})
export class DocumentsListComponent implements OnInit {
  documents$: Observable<Document[]> = of([]);
  constructor(private documentsService: DocumentsService) {}

  ngOnInit(): void {
    this.documents$ = this.documentsService.all();
  }
}
