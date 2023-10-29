import { Component, OnInit } from '@angular/core';
import { Lancamento } from '../Models/lancamentoContaCorrente';
import { Observable, map, mergeMap, of, take } from 'rxjs';
import { LancamentoService } from '../Services/Lancamento.service';

@Component({
  selector: 'app-lancamento',
  templateUrl: './lancamento.component.html',
  styleUrls: ['./lancamento.component.css']
})
export class LancamentoComponent implements OnInit {

  public lancamento$ = new Observable<Lancamento[]>();
  public valortotalLancamentos : number = 0;
  public filtro : boolean = false;
  public dataFiltro : string = ""
  public lancamentoSelecionado !: Lancamento | null;

  constructor(private lancamentoService : LancamentoService) { }

  ngOnInit() {

    this.lancamentoSelecionado = null;

    //Quando alguma ação como inserção,update e etc foi realizada e será atualizado os elementos, é verificado se o filtro está ativo
    if(this.dataFiltro){

      this.filtrarData();
    }
    else {

      const date = new Date();
      const ano = date.getFullYear();
      const mes = (date.getMonth() + 1).toString().padStart(2, '0'); // Adicione 1 ao mês para compensar a base 0
      const dia = date.getDate().toString().padStart(2, '0');
  
     const dataFormatada = `${ano}-${mes}-${dia}`;
  
      this.lancamento$ = this.lancamentoService.getBydate(dataFormatada,2);
        
      this.tratativadatas();
      this.calculaValorTotal();
      
    }
    
  }

  dataAtual() : string{
      const date = new Date();
      const ano = date.getFullYear();
      const mes = (date.getMonth() + 1).toString().padStart(2, '0'); // Adicione 1 ao mês para compensar a base 0
      const dia = date.getDate().toString().padStart(2, '0');
  
     const dataFormatada = `${ano}-${mes}-${dia}`;
     return dataFormatada;
  }

  tratativadatas(){

    this.lancamento$ = this.lancamento$.pipe(
      map((lancamentos) => {
        return lancamentos.map((lancamento) => {
          const novoLancamento = { ...lancamento };
          novoLancamento.data = this.formatarData(novoLancamento.data)
          return novoLancamento;
        });
      })
    );
  }

  formatarData(data: string) : string{
    const dataFormatada = new Date(data).toISOString().split('T')[0];
    return dataFormatada;
  }


  calculaValorTotal(){

    this.valortotalLancamentos = 0;

    this.lancamento$.pipe(
      mergeMap(lancamentos => of(...lancamentos)),
       take(10) // Limita a 10 iterações no máximo
      ).subscribe(lancamento => {
         this.valortotalLancamentos += lancamento.valor;
    })

    const valor = this.valortotalLancamentos.toFixed(2);
    this.valortotalLancamentos = parseFloat(valor);
  }

  editarLancamento(lancamento : Lancamento){

       this.lancamentoSelecionado = lancamento;
       
  }

  cadastrarlancamento(){
    this.lancamentoSelecionado = new Lancamento();
    this.lancamentoSelecionado.avulso = "Avulso";
    this.lancamentoSelecionado.status = "Válido";
  }

  salvarLancamento(){

      //Caso em que o form está inválido
      if(this.lancamentoSelecionado?.data === '' || this.lancamentoSelecionado?.descricao === '' || this.lancamentoSelecionado?.valor === null)
      {
        return;
      }

    //Verificando se é um novo lançamento
    if(this.lancamentoSelecionado!.id == 0){

        this.lancamentoSelecionado!.avulso = "0";
        this.lancamentoSelecionado!.status = "0";

      this.lancamentoService.postAvulso(this.lancamentoSelecionado!).subscribe(() => this.ngOnInit());
      
    }
    else{
      this.lancamentoService.patchAtualizarValorData(this.lancamentoSelecionado!.id,this.lancamentoSelecionado!.valor,this.lancamentoSelecionado!.data).subscribe(() => this.ngOnInit());
    }

  }

  limparLancamentoSelecionado(){
    this.lancamentoSelecionado = null;
    this.ngOnInit();
  }

  cancelarLancamento(id : number){
    this.lancamentoService.patchCancelarLancamento(id).subscribe(() => this.ngOnInit());
  }
  
  ativarFiltro(){
    if(this.filtro){
      this.filtro = false;
    }
    else{
      this.filtro = true;
    }
   
  }

  filtrarData(){

    this.lancamento$ = this.lancamentoService.getBydate(this.dataFiltro,2);
    this.tratativadatas();
    this.calculaValorTotal();
    
  }
}
