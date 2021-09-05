import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { OrdersComponent } from './orders-page/orders.component';
import { OrdersService } from './orders.service';

@NgModule({
  declarations: [
    OrdersComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    OrdersService
  ]
})

export class OrdersModule { 
  static forRoot(): ModuleWithProviders<OrdersModule> {
    return {
      ngModule: OrdersModule
    }
  }
}
