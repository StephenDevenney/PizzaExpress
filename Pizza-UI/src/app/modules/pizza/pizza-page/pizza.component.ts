import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Product } from '../../../shared/classes/products/products';
import { BaseComponent } from '../../../shared/components/base.component';
import { PizzaService } from '../pizza.service';
import { BasketItem } from '../../../shared/classes/products/BasketItem';

@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html'
})
export class PizzaComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;
  public pizzaData: Array<Product> = new Array<Product>();
  constructor(private injector: Injector,
              private pizzaService: PizzaService) {
    super(injector);
  }

  async ngOnInit(): Promise<void> {
    await this.loadPizza();
  }

  async loadPizza() {
    this.loader.start();
    await this.pizzaService.getPizza().then(async (res: Array<Product>) => {
      this.pizzaData = res;
      this.loader.stop();
      this.isLoaded = true;
    }).catch((err: HttpErrorResponse) => {
      this.loader.stop();
    });
  }

  async addToBasket(item: Product) {
    this.loader.startBackground();
    let newItem = new BasketItem();
    newItem.productItem = item;
    newItem.productCount = 1 // TODO: Add count for adding product in UI
    await this.pizzaService.addProductToBasket(newItem).then(() => {
      this.messageService.add({ severity:'success', summary: 'Success', detail: item.name + ' added to basket.', life: 2600 });
      this.loader.stopBackground();
    }).catch((err: HttpErrorResponse) => {
      this.loader.stopBackground();
    });
  }
}
