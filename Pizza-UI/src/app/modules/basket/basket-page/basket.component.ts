import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { BasketItem } from 'src/app/shared/classes/products/BasketItem';
import { Product } from 'src/app/shared/classes/products/products';
import { BaseComponent } from '../../../shared/components/base.component';
import { BasketService } from '../basket.service';

@Component({
  selector: 'basket',
  templateUrl: './basket.component.html'
})
export class BasketComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;
  public basketData: Array<BasketItem> = new Array<BasketItem>();
  public totalCost: number = 0;
  
  constructor(private injector: Injector,
              private basketService: BasketService) {
    super(injector);
  }

  async ngOnInit(): Promise<void> {
    await this.loadBasket();
  }

  public async loadBasket() {
    this.loader.start();
    await this.basketService.getBasket().catch((err: HttpErrorResponse) => {
      this.loader.stop();
    }).then((res: Array<BasketItem>) => {
      this.basketData = res;
      this.loader.stop();
      this.isLoaded = true;
    });
  }

  public async removeFromBasket(item: BasketItem) {
    this.loader.startBackground();
    await this.basketService.removeFromBasket(item).then((res: Array<BasketItem>) => {
      this.basketData = this.basketData.filter(b => b != item);
      this.loader.stopBackground();
      this.messageService.add({ severity:'success', summary: 'Success', detail: item.productItem.name + ' removed from basket.', life: 2600 });
    }).catch((err: HttpErrorResponse) => {
      this.loader.stopBackground();
    });
  }

  public async confirmOrder() {
    this.loader.start();
    await this.basketService.confirmOrder(this.basketData).then(() => {
      this.basketData = new Array<BasketItem>();
      this.loader.stop();
    }).catch((err: HttpErrorResponse) => {
      this.loader.stop();
    });
  }
}
