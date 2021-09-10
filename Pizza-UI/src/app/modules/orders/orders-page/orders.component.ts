import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Order } from '../../../shared/classes/products/order';
import { BaseComponent } from '../../../shared/components/base.component';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;
  public orderData: Array<Order> = new Array<Order>();

  constructor(private injector: Injector,
              private ordersService: OrdersService) {
    super(injector);
  }

  async ngOnInit(): Promise<void> {
    await this.loadOrders();
  }

  public async loadOrders() {
    this.loader.start();
    await this.ordersService.getOrders().then((res: Array<Order>) => {
      this.orderData = res;
      this.loader.stop();
      this.isLoaded = true;
    }).catch((err: HttpErrorResponse) => {
      this.loader.stop();
    });
  }
}
