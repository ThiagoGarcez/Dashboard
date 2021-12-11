import { Component, OnInit } from "@angular/core";
import { Marca } from "app/models/marca.modul";
import { MarcaService } from "app/services/marca.service";

@Component({
  selector: "app-marcas",
  templateUrl: "./marcas.component.html",
  styleUrls: ["./marcas.component.scss"],
})
export class MarcasComponent implements OnInit {
  marcas: Marca[];
  loading: boolean = false;

  constructor(
    private marcaService: MarcaService
  ) // private produtoForm: ProdutoFormService
  {}

  ngOnInit() {
    this.obterMarcas();
  }

  private obterMarcas() {
    this.marcaService.obterTodosMarcas().subscribe((resposta) => {
      this.marcas = resposta;
    });
  }

  // adicionarProduto() {
  //   this.loading = true;
  //   this.produtoForm.abrirModal(1, "Cadastro de Produto").then((result) => {
  //     if(result){
  //       this.obterProdutos();
  //     }
  //   });
  // }
}
