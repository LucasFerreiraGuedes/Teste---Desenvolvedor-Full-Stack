/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LancamentoService } from './Lancamento.service';

describe('Service: Lancamento', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LancamentoService]
    });
  });

  it('should ...', inject([LancamentoService], (service: LancamentoService) => {
    expect(service).toBeTruthy();
  }));
});
