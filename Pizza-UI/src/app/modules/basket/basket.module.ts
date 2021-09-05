import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { BasketComponent } from './basket-page/basket.component';
import { BasketService } from './basket.service';

@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    BasketService
  ]
})

export class BasketModule { 
  static forRoot(): ModuleWithProviders<BasketModule> {
    return {
      ngModule: BasketModule
    }
  }
}
