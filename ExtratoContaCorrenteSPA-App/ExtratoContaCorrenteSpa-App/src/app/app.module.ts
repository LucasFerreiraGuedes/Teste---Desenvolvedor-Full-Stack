import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LancamentoComponent } from './lancamento/lancamento.component';
import { NavComponent } from './nav/nav.component';
import { LancamentoService } from './Services/Lancamento.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [		
    AppComponent,
      LancamentoComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [LancamentoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
