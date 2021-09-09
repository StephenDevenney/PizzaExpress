import { Injectable } from '@angular/core';
import { Product } from './products';

@Injectable()
export class BasketItem {
    public basketId: number = 0;
    public productItem: Product = new Product;
    public productCount: number = 0;
}