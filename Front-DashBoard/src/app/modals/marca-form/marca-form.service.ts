import { Injectable } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { MarcaFormComponent } from "./marca-form.component";


@Injectable({
    providedIn: 'root'
})
export class MarcaFormService {

    constructor(
        private modalService: NgbModal
    ) { }

    public abrirModal(
        marcaId:  number = 0,
        btnOkText: string = 'Enviar',
        btnCancelText: string = 'Cancelar',
        dialogSize: 'sm' | 'lg' = 'lg'): Promise<boolean> {
        const modalRef = this.modalService.open(MarcaFormComponent, { size: dialogSize, centered: true });
        modalRef.componentInstance.marcaId = marcaId;
        modalRef.componentInstance.btnOkText = btnOkText;
        modalRef.componentInstance.btnCancelText = btnCancelText;

        return modalRef.result;
    }
}
