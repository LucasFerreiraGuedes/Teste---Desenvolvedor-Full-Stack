import { Component, OnInit } from '@angular/core';
import { Lancamento } from '../Models/lancamentoContaCorrente';
import { Observable, map } from 'rxjs';
import { LancamentoService } from '../Services/Lancamento.service';

@Component({
  selector: 'app-lancamento',
  templateUrl: './lancamento.component.html',
  styleUrls: ['./lancamento.component.css']
})
export class LancamentoComponent implements OnInit {

  public lancamento$ = new Observable<Lancamento[]>();

  public lancamentoSelecionado !: Lancamento | null;

  constructor(private lancamentoService : LancamentoService) { }

  ngOnInit() {

    const date = new Date();
    const ano = date.getFullYear();
    const mes = (date.getMonth() + 1).toString().padStart(2, '0'); // Adicione 1 ao mês para compensar a base 0
    const dia = date.getDate().toString().padStart(2, '0');

   const dataFormatada = `${ano}-${mes}-${dia}`;

    this.lancamento$ = this.lancamentoService.getBydate(dataFormatada,2);

    this.lancamento$ = this.lancamento$.pipe(
      map((lancamentos) => {
        return lancamentos.map((lancamento) => {
          const novoLancamento = { ...lancamento };
          novoLancamento.data = this.formatarData(novoLancamento.data)
          return novoLancamento;
        });
      })
    );


    this.lancamentoSelecionado = null;
  }

  formatarData(data: string) : string{
    const dataFormatada = new Date(data).toISOString().split('T')[0];
    return dataFormatada;
  }

  editarLancamento(lancamento : Lancamento){
       this.lancamentoSelecionado = lancamento;
       
  }

  cadastrarlancamento(){
    this.lancamentoSelecionado = new Lancamento();
  }

  salvarLancamento(){

    
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
  }

  cancelarLancamento(id : number){
    this.lancamentoService.patchCancelarLancamento(id).subscribe(() => this.ngOnInit());
  }

}
