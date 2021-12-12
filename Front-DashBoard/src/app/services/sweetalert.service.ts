import { Injectable } from "@angular/core";
import { TestBed } from "@angular/core/testing";
import Swal, { SweetAlertResult } from "sweetalert2";
@Injectable({
  providedIn: "root",
})
export class SweetAlertService {
  sweetAlertResult: SweetAlertResult<any>;

  constructor() {}

  async alertaDelete() {
    await Swal.fire({
      title: "Tem certeza?",
      text: "Essa ação não poderá ser revertida",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      cancelButtonText: "Cancelar",
      confirmButtonText: "Sim, delete!",
    }).then((result) => {
      this.sweetAlertResult = result;
    });

    return this.sweetAlertResult;
  }

  alertaSucesso(titulo: string, texto: string) {
    Swal.fire({
      title: titulo,
      text: texto,
      icon: "success",
      showConfirmButton: false,
      timer: 1500,
      timerProgressBar: true,
    });
  }

  alertaFalha(titulo: string, texto: string) {
    Swal.fire({
      title: titulo,
      text: texto,
      icon: "error",
      showConfirmButton: false,
      timer: 1500,
      timerProgressBar: true,
    });
  }
}
