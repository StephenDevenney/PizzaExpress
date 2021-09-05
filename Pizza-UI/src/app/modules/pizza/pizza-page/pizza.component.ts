import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Pizza } from 'src/app/shared/classes/products';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { PizzaService } from '../pizza.service';

@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html'
})
export class PizzaComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;
  public pizzaData: Array<Pizza> = new Array<Pizza>();
  constructor(private injector: Injector,
              private pizzaService: PizzaService) {
    super(injector);
  }

  ngOnInit(): void {
    this.isLoaded = true;
  }

  async loadPizza() {
    this.loader.start();
    await this.pizzaService.getPizza().catch((err: HttpErrorResponse) => {
      this.loader.stop();
    }).then(async (res: Array<Pizza>) => {
      this.pizzaData = res;
      this.loader.stop();
    });
  }
}
