import { Injectable } from '@angular/core';

@Injectable()
export class Product {
    public productId: number = 0;
    public name: string = "";
    public description: string = "";
    public price: number = 0;
    public imageLink: string = "";
    public ProductId: number = 0;
}