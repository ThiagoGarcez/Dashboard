import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { Marca } from "app/models/marca.model";
import { RespostaPadrao } from "app/models/resposta-padrao.model";
import { MarcaService } from "app/services/marca.service";
import { NotificacaoService } from "app/services/notificacao.service";

@Component({
  selector: "app-marca-form",
  templateUrl: "./marca-form.component.html",
  styleUrls: ["./marca-form.component.scss"],
})
export class MarcaFormComponent implements OnInit {
  @Input() btnOkText: string;
  @Input() btnCancelText: string;
  @Input() marcaId: number;

  loading: boolean;
  marcaForm: FormGroup;

  constructor(
    private activeModal: NgbActiveModal,
    private notificacaoService: NotificacaoService,
    private marcaService: MarcaService,
    private formBuilder: FormBuilder
  ) {
    this.marcaForm = this.formBuilder.group({
      nome: new FormControl(),
      urlLogomarca: new FormControl(),
    });
  }

  async ngOnInit() {
    if (this.marcaId > 0) this.obterMarca(this.marcaId);
  }

  public decline() {
    this.activeModal.close(false);
  }

  public accept() {
    const marca: Marca = new Marca();
    marca.id = this.marcaId;
    marca.nome = this.marcaForm.value.nome;
    marca.urlLogomarca = this.marcaForm.value.urlLogomarca;

    if (this.marcaId == 0) this.adicionarMarca(marca);
    else this.editarMarca(marca);
  }

  private adicionarMarca(marca: Marca) {
    this.marcaService
      .adicionarMarca(marca)
      .toPromise()
      .then(
        (resposta) => {
          this.tratarResposta(resposta);
        },
        (err) => {
          this.notificacaoService.mensagemErro(err.error);
          this.loading = false;
        }
      )
      .finally(() => this.activeModal.close(true));
  }

  private editarMarca(marca: Marca) {
    this.marcaService
      .editarMarca(marca)
      .toPromise()
      .then(
        (resposta) => {
          this.tratarResposta(resposta);
        },
        (err) => {
          this.notificacaoService.mensagemErro(err.error);
          this.loading = false;
        }
      )
      .finally(() => this.activeModal.close(true));
  }

  private tratarResposta(resposta: RespostaPadrao) {
    resposta.sucesso
      ? this.notificacaoService.mensagemSucesso(resposta.mensagem)
      : this.notificacaoService.mensagemErro(resposta.mensagem);
  }

  private async obterMarca(marcaId: number) {
    var marca = await this.marcaService.obterMarca(marcaId);
    this.marcaForm.controls["nome"].setValue(marca.nome);
    this.marcaForm.controls["urlLogomarca"].setValue(marca.urlLogomarca);
  }

  dismiss() {
    this.activeModal.dismiss();
  }
}
