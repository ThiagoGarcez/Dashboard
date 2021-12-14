import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Departamento } from 'app/models/departamento.model.ts';
import { RespostaPadrao } from 'app/models/resposta-padrao.model';
import { DepartamentoService } from 'app/services/departamento.service';
import { NotificacaoService } from 'app/services/notificacao.service';

@Component({
  selector: 'app-departamento-form',
  templateUrl: './departamento-form.component.html',
  styleUrls: ['./departamento-form.component.css']
})
export class DepartamentoFormComponent implements OnInit {

  @Input() btnOkText: string;
  @Input() btnCancelText: string;
  @Input() departamentoId: number;

  loading: boolean;
  departamentoForm: FormGroup;

  constructor(
    private activeModal: NgbActiveModal,
    private notificacaoService: NotificacaoService,
    private departamentoService: DepartamentoService,
    private formBuilder: FormBuilder
  ) {
    this.departamentoForm = this.formBuilder.group({
      nome: new FormControl()
    });
  }

  async ngOnInit() {
    if (this.departamentoId > 0) this.obterDepartamento(this.departamentoId);
  }

  public decline() {
    this.activeModal.close(false);
  }

  public accept() {
    const departamento: Departamento = new Departamento();
    departamento.id = this.departamentoId;
    departamento.nome = this.departamentoForm.value.nome;

    if (this.departamentoId == 0) this.adicionarDepartamento(departamento);
    else this.editarDepartamento(departamento);
  }

  private adicionarDepartamento(departamento: Departamento) {
    this.departamentoService
      .adicionarDepartamento(departamento)
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

  private editarDepartamento(departamento: Departamento) {
    this.departamentoService
      .editarDepartamento(departamento)
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

  private async obterDepartamento(departamentoId: number) {
    var departamento = await this.departamentoService.obterDepartamento(departamentoId);
    this.departamentoForm.controls["nome"].setValue(departamento.nome);
  }

  dismiss() {
    this.activeModal.dismiss();
  }

}
