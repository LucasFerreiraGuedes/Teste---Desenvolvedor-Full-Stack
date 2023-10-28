import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../Environments/environment';
import { Lancamento } from '../Models/lancamentoContaCorrente';

@Injectable()
export class LancamentoService {

baseUrl = `${environment.baseUrlApi}/Lancamento`;

constructor(private http: HttpClient) { }



  getBydate(data : string, intervalo: number){
    
     return this.http.get<Lancamento[]>(`${this.baseUrl}/GetByDate?date=${data}&intervalo=${intervalo}`)
  }

  postAvulso(lancamento : Lancamento){
    return this.http.post<Lancamento>(`${this.baseUrl}`,lancamento);
  }

  patchCancelarLancamento(id : number){
    return this.http.patch<Lancamento>(`${this.baseUrl}/CancelarLancamento`,id);
  }

  patchAtualizarValorData(id: number,valor: number,data : string){

    const lancamentoAnonimo = {
        id : id,
        valor : valor,
        data : data
    };

    console.log(lancamentoAnonimo);

    return this.http.patch<Lancamento>(`${this.baseUrl}/AttValorData`,lancamentoAnonimo);
  }
}
