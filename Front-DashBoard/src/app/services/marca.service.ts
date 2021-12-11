import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Marca } from "app/models/marca.model";
import { RespostaPadrao } from "app/models/resposta-padrao.model";
import { environment } from "environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class MarcaService {
  constructor(private httpClient: HttpClient) {}

  obterTodosMarcas(): Observable<Marca[]> {
    return this.httpClient.get<Marca[]>(
      `${environment.urlApi}/Marca/obterTodasMarcas/`
    );
  }

  adicionarMarca(marca: Marca): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(
      `${environment.urlApi}/Marca/adicionarMarca`,
      marca
    );
  }

  editarMarca(marca: Marca): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(
      `${environment.urlApi}/Marca/atualizarMarca`,
      marca
    );
  }

  removerMarca(marcaId: number): Observable<RespostaPadrao> {
    return this.httpClient
      .delete<RespostaPadrao>(
        `${environment.urlApi}/Marca/removerMarca/${marcaId}`
      );
  }

  obterMarca(marcaId: number): Promise<Marca> {
    return this.httpClient
      .get<Marca>(`${environment.urlApi}/Marca/obterMarca/${marcaId}`)
      .toPromise();
  }
}
