import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { PizzaComponent } from './pizza-page/pizza.component';
import { PizzaService } from './pizza.service';
import { DataViewModule } from 'primeng/dataview';

@NgModule({
  declarations: [
    PizzaComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    DataViewModule
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
