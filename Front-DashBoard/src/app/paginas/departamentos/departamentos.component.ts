import { Component, OnInit } from '@angular/core';
import { DepartamentoFormService } from 'app/modals/departamento-form/departamento-form.service';
import { Departamento } from 'app/models/departamento.model.ts';
import { DepartamentoService } from 'app/services/departamento.service';
import { NotificacaoService } from 'app/services/notificacao.service';
import { SweetAlertService } from 'app/services/sweetalert.service';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})
export class DepartamentoComponent implements OnInit {

  departamentos: Departamento[];
  loading: boolean = false;

  constructor(
    private departamentoService: DepartamentoService,
    private notificacaoService: NotificacaoService,
    private departamentoForm: DepartamentoFormService,
    private sweetAlertService: SweetAlertService
  ) {}

  ngOnInit() {
    this.obterDepartamentos();
  }

  private obterDepartamentos() {
    this.departamentoService.obterTodosDepartamentos().subscribe((resposta) => {
      this.departamentos = resposta;
    });
  }

  adicionarDepartamento() {
    this.loading = true;
    this.departamentoForm.abrirModal().then((result) => {
      if (result) {
        this.obterDepartamentos();
      }
    });
  }

  editarMarca(marcaId: number) {
    this.loading = true;
    this.departamentoForm.abrirModal(marcaId).then((result) => {
      if (result) {
        this.obterDepartamentos();
      }
    });
  }

  removerMarca(marcaId: number) {
    this.sweetAlertService.alertaDelete().then((result) => {
      if (result.isConfirmed) {
        this.loading = true;
        this.departamentoService
          .removerDepartamento(marcaId)
          .toPromise()
          .then(
            (resposta) => {
              resposta.sucesso
                ? this.sweetAlertService.alertaSucesso(
                    "Deletado",
                    resposta.mensagem
                  )
                : this.sweetAlertService.alertaFalha(
                    "Opss!",
                    resposta.mensagem
                  );
            },
            (err) => {
              this.notificacaoService.mensagemErro(err.error);
            }
          )
          .finally(() => {
            this.obterDepartamentos();
            this.loading = false;
          });
      }
    });
  }
}
