import { Component, OnInit } from "@angular/core";
import { ProdutoFormService } from "app/modals/produto-form/produto-form.service";
import { Produto } from "app/models/produto.model";
import { ProdutoService } from "app/services/produto.service";
import { of } from "rxjs";

@Component({
  selector: "app-produtos",
  templateUrl: "./produtos.component.html",
  styleUrls: ["./produtos.component.scss"],
})
export class ProdutosComponent implements OnInit {
  produtos: Produto[];
  loading: boolean = false;

  constructor(
    private produtoService: ProdutoService,
    private produtoForm: ProdutoFormService
  ) {}

  ngOnInit() {
    this.obterProdutos();
  }

  private obterProdutos() {
    this.produtoService.obterTodosProdutos().subscribe((resposta) => {
      this.produtos = resposta;
    });
  }

  adicionarProduto() {
    this.loading = true;
    this.produtoForm.abrirModal(1, "Cadastro de Produto").then((result) => {
      if(result){
        this.obterProdutos();
      }
    });
  }
}
