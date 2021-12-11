import { Component, Inject, Input, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { Produto } from "app/models/produto.model";
import { NotificacaoService } from "app/services/notificacao.service";
import { ProdutoService } from "app/services/produto.service";

@Component({
  selector: "app-produto-form",
  templateUrl: "./produto-form.component.html",
  styleUrls: ["./produto-form.component.scss"],
})
export class ProdutoFormComponent implements OnInit {
  @Input() btnOkText: string;
  @Input() btnCancelText: string;
  @Input() titulo: string;
  @Input() produtoId: number;

  loading: boolean;
  produtoForm: FormGroup;

  constructor(
    private activeModal: NgbActiveModal,
    private notificacaoService: NotificacaoService,
    private produtoService: ProdutoService,
    private formBuilder: FormBuilder
  ) {
    this.produtoForm = this.formBuilder.group({
      nome: new FormControl(),
      descricao: new FormControl(),
      ativo: new FormControl(),
    });
  }

  async ngOnInit() {}

  public decline() {
    this.activeModal.close(false);
  }

  public accept() {
    const produto: Produto = new Produto(
      this.produtoId,
      this.produtoForm.value.nome,
      this.produtoForm.value.descricao,
      this.produtoForm.value.ativo ?? false
    );

    this.produtoService
      .adicionarProduto(produto)
      .toPromise()
      .then(
        (resposta) => {
          resposta.sucesso
            ? this.notificacaoService.mensagemSucesso(resposta.mensagem)
            : this.notificacaoService.mensagemErro(resposta.mensagem);
        },
        (err) => {
          console.log("erro: ", err);
          this.loading = false;
        }
      )
      .finally(() => this.activeModal.close(true));
  }

  dismiss() {
    this.activeModal.dismiss();
  }
}
