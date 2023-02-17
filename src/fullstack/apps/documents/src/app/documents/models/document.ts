import { DocumentDto } from '../dto/document-dto';

export class Document {
  id: string;
  constructor(dto: DocumentDto) {
    this.id = dto.id;
  }
}
