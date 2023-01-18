import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dokument, Dokumententyp } from './models/dokument';
import { ErstelleDokumentModalService } from './erstelle-dokument/erstelle-dokument-modal.service';
import { tap } from 'rxjs';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  dokumente: Dokument[] = [];

  selectedDocument: Dokument | undefined

  constructor(public http: HttpClient, private eDMService: ErstelleDokumentModalService ) {
    eDMService.saved.pipe(tap(() => {
      this.ladeDokumente
    })).subscribe()
    this.ladeDokumente()
  }

  openDocumentCreation() {
    this.eDMService.open();
  }

  selectDocument(dokument: Dokument) {
    this.selectedDocument = dokument;
  }

  async ladeDokumente() {
    this.dokumente = (await this.http.get<Dokument[]>(environment.baseurl + '/dokumente').toPromise()) || []
  }

  async selectedDocumentAnnehmen() {
    if(this.selectedDocument) {
      this.selectedDocument.typ = Dokumententyp.VERSICHERUNGSSCHEIN;
      await this.http.patch<Dokument>(environment.baseurl + '/dokumente/' + this.selectedDocument.id, this.selectedDocument).toPromise()
      await this.ladeDokumente()
    }
  }
  async selectedDocumentAusstellen() {
    if(this.selectedDocument) {
      await this.http.post<Dokument>(environment.baseurl + '/dokumente/' + this.selectedDocument.id + '/ausstellen', this.selectedDocument).toPromise()
      await this.ladeDokumente()
    }
  }
  
  async selectedDocumentLoeschen() {
    if(this.selectedDocument) {
      await this.http.delete<Dokument>(environment.baseurl + '/dokumente/' + this.selectedDocument.id).toPromise()
      await this.ladeDokumente()
    }
  }

}
