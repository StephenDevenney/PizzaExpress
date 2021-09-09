import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { PizzaComponent } from './pizza-page/pizza.component';
import { PizzaService } from './pizza.service';

@NgModule({
  declarations: [
    PizzaComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    PizzaService
  ]
})

export class PizzaModule { 
  static forRoot(): ModuleWithProviders<PizzaModule> {
    return {
      ngModule: PizzaModule
    }
  }
}
