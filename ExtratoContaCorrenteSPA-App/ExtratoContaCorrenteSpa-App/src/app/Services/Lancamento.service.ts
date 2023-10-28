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

}
