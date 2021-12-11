import { Component, OnInit, ViewChild } from "@angular/core";
import { SwalComponent } from "@sweetalert2/ngx-sweetalert2";
import { MarcaFormComponent } from "app/modals/marca-form/marca-form.component";
import { MarcaFormService } from "app/modals/marca-form/marca-form.service";
import { Marca } from "app/models/marca.model";
import { MarcaService } from "app/services/marca.service";
import { NotificacaoService } from "app/services/notificacao.service";

@Component({
  selector: "app-marcas",
  templateUrl: "./marcas.component.html",
  styleUrls: ["./marcas.component.scss"],
})
export class MarcasComponent implements OnInit {
  marcas: Marca[];
  loading: boolean = false;

  constructor(
    private marcaService: MarcaService,
    private marcaForm: MarcaFormService,
    private notificacaoService: NotificacaoService
  ) {}

  ngOnInit() {
    this.obterMarcas();
  }

  private obterMarcas() {
    this.marcaService.obterTodosMarcas().subscribe((resposta) => {
      this.marcas = resposta;
    });
  }

  adicionarMarca() {
    this.loading = true;
    this.marcaForm.abrirModal().then((result) => {
      if (result) {
        this.obterMarcas();
      }
    });
  }

  editarMarca(marcaId: number) {
    this.loading = true;
    this.marcaForm.abrirModal(marcaId).then((result) => {
      if (result) {
        this.obterMarcas();
      }
    });
  }

  removerMarca(marcaId: number) {
    this.loading = true;
    this.marcaService
      .removerMarca(marcaId)
      .toPromise()
      .then(
        (resposta) => {
          resposta.sucesso
            ? this.notificacaoService.mensagemSucesso(resposta.mensagem)
            : this.notificacaoService.mensagemErro(resposta.mensagem);
        },
        (err) => {
          this.notificacaoService.mensagemErro(err.error);
        }
      )
      .finally(() => {
        this.obterMarcas();
        this.loading = false;
      });
  }
}
