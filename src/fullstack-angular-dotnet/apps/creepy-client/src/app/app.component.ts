import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import {HttpClient} from "@angular/common/http";
import {ErstelleDokumentModalService} from "./erstelle-dokument/erstelle-dokument-modal.service";
import {tap} from "rxjs";
import {DokumentenlisteEintragDto} from "./models/dokument";
import {environment} from "../environments/environment";
import {CommonModule} from "@angular/common";
import {ErstelleDokumentModal} from "./erstelle-dokument/erstelle-dokument-modal.component";

@Component({
  standalone: true,
  imports: [CommonModule, RouterModule, ErstelleDokumentModal],
  selector: 'fullstack-angular-dotnet-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  dokumente: DokumentenlisteEintragDto[] = [];

  selectedDocument: DokumentenlisteEintragDto | undefined

  constructor(public http: HttpClient, private eDMService: ErstelleDokumentModalService ) {
    eDMService.saved.pipe(tap(() => {
      this.ladeDokumente()
    })).subscribe()
    this.ladeDokumente()
  }

  openDocumentCreation() {
    this.eDMService.open();
  }

  selectDocument(dokument: DokumentenlisteEintragDto) {
    this.selectedDocument = dokument;
  }

  async ladeDokumente() {
    this.dokumente = (await this.http.get<DokumentenlisteEintragDto[]>(environment.baseurl + '/dokumente').toPromise()) || []
  }

  async selectedDocumentAnnehmen() {
    if(this.selectedDocument) {
      await this.http.post<void>(environment.baseurl + '/dokumente/' + this.selectedDocument.id + '/annehmen', null).toPromise()
      this.selectedDocument = undefined;
      await this.ladeDokumente()

    }
  }
  async selectedDocumentAusstellen() {
    if(this.selectedDocument) {
      await this.http.post<void>(environment.baseurl + '/dokumente/' + this.selectedDocument.id + '/ausstellen', null).toPromise()
      this.selectedDocument = undefined;
      await this.ladeDokumente()
    }
  }
}
