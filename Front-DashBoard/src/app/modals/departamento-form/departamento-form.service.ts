import { Injectable } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DepartamentoFormComponent } from "./departamento-form.component";

@Injectable({
    providedIn: 'root'
})
export class DepartamentoFormService {

    constructor(
        private modalService: NgbModal
    ) { }

    public abrirModal(
        departamentoId:  number = 0,
        btnOkText: string = 'Enviar',
        btnCancelText: string = 'Cancelar',
        dialogSize: 'sm' | 'lg' = 'lg'): Promise<boolean> {
        const modalRef = this.modalService.open(DepartamentoFormComponent, { size: dialogSize, centered: true });
        modalRef.componentInstance.marcaId = departamentoId;
        modalRef.componentInstance.btnOkText = btnOkText;
        modalRef.componentInstance.btnCancelText = btnCancelText;

        return modalRef.result;
    }
}
