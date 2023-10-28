import { Component, OnInit } from '@angular/core';
import { Lancamento } from '../Models/lancamentoContaCorrente';
import { Observable } from 'rxjs';
import { LancamentoService } from '../Services/Lancamento.service';

@Component({
  selector: 'app-lancamento',
  templateUrl: './lancamento.component.html',
  styleUrls: ['./lancamento.component.css']
})
export class LancamentoComponent implements OnInit {

  public lancamento$ = new Observable<Lancamento[]>();
  public date = new Date();
  public data = new Date(`${this.date.getFullYear()}-${(this.date.getMonth() + 1).toString().padStart(2, '0')}-${this.date.getDate().toString().padStart(2, '0')}`);

  constructor(private lancamentoService : LancamentoService) { }

  ngOnInit() {

    const date = new Date();
    const ano = date.getFullYear();
    const mes = (date.getMonth() + 1).toString().padStart(2, '0'); // Adicione 1 ao mês para compensar a base 0
    const dia = date.getDate().toString().padStart(2, '0');

   const dataFormatada = `${ano}-${mes}-${dia}`;
    console.log(dataFormatada)
    this.lancamento$ = this.lancamentoService.getBydate(dataFormatada,2)
  }

}
