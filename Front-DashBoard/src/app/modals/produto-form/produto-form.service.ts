import { Injectable } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { ProdutoFormComponent } from "./produto-form.component";


@Injectable({
    providedIn: 'root'
})
export class ProdutoFormService {

    constructor(
        private modalService: NgbModal
    ) { }

    public abrirModal(
        produtoId:  number,
        titulo: string,
        btnOkText: string = 'Enviar',
        btnCancelText: string = 'Cancelar',
        dialogSize: 'sm' | 'lg' = 'lg'): Promise<boolean> {
        const modalRef = this.modalService.open(ProdutoFormComponent, { size: dialogSize, centered: true });
        modalRef.componentInstance.produtoId = produtoId;
        modalRef.componentInstance.btnOkText = btnOkText;
        modalRef.componentInstance.btnCancelText = btnCancelText;

        return modalRef.result;
    }
}
