import { Injectable } from '@angular/core';

@Injectable()
export class Product {
    public ProductId: number = 0;
    public Name: string = "";
    public Description: string = "";
    public Price: number = 0;
    public imageLink: string = "";
} 