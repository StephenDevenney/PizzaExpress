import { Injectable } from '@angular/core';
import { Product } from './products';

@Injectable()
export class Order {
    public orderId: number = 0;
    public productItem: Array<OrderedProduct> = new Array<OrderedProduct>();
    public orderCode: string = "";
    public orderStatus: OrderStatusVM = new OrderStatusVM();
}

@Injectable()
export class OrderedProduct {
    public orderedProductId: number = 0;
    public productItem: Product = new Product;
    public productCount: number = 0;
}

@Injectable()
export class OrderStatusVM {
    public statusId: number = 0;
    public description: string = "";
}