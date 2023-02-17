import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { DocumentDto } from './dto/document-dto';
import { Document } from './models/document';

@Injectable({ providedIn: 'root' })
export class DocumentsService {
  private baseUrl = 'https://localhost';
  constructor(private httpClient: HttpClient) {}

  all(): Observable<Document[]> {
    return this.httpClient
      .get<DocumentDto[]>(this.baseUrl)
      .pipe(map((dtos) => dtos.map((dto) => new Document(dto))));
  }
}
