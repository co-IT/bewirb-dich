import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Dokument, Dokumententyp } from '../models/dokument';

@Injectable({ providedIn: 'root' })
export class ErstelleDokumentModalService {
    private modal: any;
    public dokument: Dokument | undefined | any
    public saved = new EventEmitter<void>()

    constructor(private httpClient: HttpClient) {
        
    }

  set(modal: any) {
			this.modal = modal;
	}

	remove() {
    this.modal = undefined;
	}

  open() {
      this.modal.open();
  }

  async close(save: boolean) {
      if(save) {
          await this.httpClient.post(environment.baseurl + '/dokumente/erstellen', {...this.dokument, typ: Dokumententyp.ANGEBOT}).toPromise()
          this.saved.emit();
      }
      this.modal.close();
  }
}