import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Product } from '../../../shared/classes/products/products';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { PizzaService } from '../pizza.service';

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
    await this.pizzaService.getPizza().catch((err: HttpErrorResponse) => {
      this.loader.stop();
    }).then(async (res: Array<Product>) => {
      this.pizzaData = res;
      this.loader.stop();
      this.isLoaded = true;
    });
  }
}
