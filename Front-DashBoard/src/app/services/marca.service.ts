import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Marca } from 'app/models/marca.modul';
import { RespostaPadrao } from 'app/models/resposta-padrao.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarcaService {

  constructor(private httpClient: HttpClient) {}

  obterTodosMarcas(): Observable<Marca[]> {
    return this.httpClient.get<Marca[]>(
      `${environment.urlApi}/Marca/obterTodosMarcas/`
    );
  }

  adicionarMarca(marca: Marca): Observable<RespostaPadrao> {
    return this.httpClient.post<RespostaPadrao>(`${environment.urlApi}/Marca/adicionarMarca`, marca);
  }

}
