import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Departamento } from "app/models/departamento.model.ts";
import { Marca } from "app/models/marca.model";
import { RespostaPadrao } from "app/models/resposta-padrao.model";
import { environment } from "environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class DepartamentoService {
  constructor(private httpClient: HttpClient) {}

  obterTodosDepartamentos(): Observable<Departamento[]> {
    return this.httpClient.get<Departamento[]>(
      `${environment.urlApi}/Departamento/obterTodosDepartamentos/`
    );
  }

  adicionarDepartamento(departamento: Departamento): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(
      `${environment.urlApi}/Departamento/adicionarDepartamento`,
      departamento
    );
  }

  editarDepartamento(departamento: Departamento): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(
      `${environment.urlApi}/Departamento/atualizarDepartamento`,
      departamento
    );
  }

  removerDepartamento(departamentoId: number): Observable<RespostaPadrao> {
    return this.httpClient
      .delete<RespostaPadrao>(
        `${environment.urlApi}/Departamento/removerDepartamento/${departamentoId}`
      );
  }

  obterDepartamento(departamentoId: number): Promise<Departamento> {
    return this.httpClient
      .get<Departamento>(`${environment.urlApi}/Departamento/obterDepartamento/${departamentoId}`)
      .toPromise();
  }
}
