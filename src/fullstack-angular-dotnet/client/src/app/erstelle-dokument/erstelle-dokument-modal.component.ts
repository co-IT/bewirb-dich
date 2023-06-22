import { Component,  ElementRef, OnInit, OnDestroy } from '@angular/core';
import { ErstelleDokumentModalService } from './erstelle-dokument-modal.service';



@Component({ 
    selector: 'dokument-modal', 
    templateUrl: 'erstelle-dokument-modal.component.html', 
    styleUrls: ['erstelle-dokument-modal.component.scss'],
})
export class ErstelleDokumentModal implements OnInit, OnDestroy {
    
    private element: any;

    constructor(public erstelleDokumentModalService: ErstelleDokumentModalService, private el: ElementRef) {
        this.element = el.nativeElement;
    }

    ngOnInit(): void {

        document.body.appendChild(this.element);

        this.element.addEventListener('click', (el: any )=> {
            if (el.target.className === 'modal') {
                this.close();
            }
        });

        this.erstelleDokumentModalService.set(this);
    }

    ngOnDestroy(): void {
        this.erstelleDokumentModalService.remove();
        this.element.remove();
    }

    open(): void {
        this.erstelleDokumentModalService.dokument = {}
        this.element.style.display = 'block';
        document.body.classList.add('modal-open');
    }

    close(): void {
        this.element.style.display = 'none';
        document.body.classList.remove('modal-open');
    }

}