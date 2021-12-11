import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Produto } from "app/models/produto.model";
import { RespostaPadrao } from "app/models/resposta-padrao.model";
import { environment } from "environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ProdutoService {
  constructor(private httpClient: HttpClient) {}

  obterTodosProdutos(): Observable<Produto[]> {
    return this.httpClient.get<Produto[]>(
      `${environment.urlApi}/Produto/obterTodosProdutos/`
    );
  }

  adicionarProduto(produto: Produto): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(`${environment.urlApi}/Produto/adicionarProduto`, produto);
  }
}
