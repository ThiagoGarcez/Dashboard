export class Produto {
  id: number;
  nome: string;
  descricao: string;
  ativo: boolean;

  constructor(id: number, nome: string, descricao: string, ativo: boolean){
    this.id = id;
    this.nome = nome;
    this.descricao = descricao;
    this.ativo = ativo;
  }
}
