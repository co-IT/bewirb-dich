import { DocumentDto } from '../dto/document.dto';
import { DocumentType } from './document-type';

export class Document {
  id: string;
  number: string;
  createdAt: Date;
  author: string;
  type: DocumentType;

  constructor(dto: DocumentDto) {
    this.id = dto.id;
    this.number = dto.number;
    this.createdAt = new Date(dto.createdAt);
    this.author = dto.author;
    this.type = dto.type;
  }
}
