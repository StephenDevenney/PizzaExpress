import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { PizzaService } from '../pizza.service';

@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html'
})
export class PizzaComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;

  constructor(private injector: Injector,
              private pizzaService: PizzaService) {
    super(injector);
  }

  ngOnInit(): void {
    this.isLoaded = true;
  }
}
