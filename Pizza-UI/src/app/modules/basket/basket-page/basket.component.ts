import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../shared/components/base.component';
import { BasketService } from '../basket.service';

@Component({
  selector: 'basket',
  templateUrl: './basket.component.html'
})
export class BasketComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;

  constructor(private injector: Injector,
              private basketService: BasketService) {
    super(injector);
  }

  ngOnInit(): void {
    this.isLoaded = true;
  }
}
