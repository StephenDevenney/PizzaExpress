import { Pipe, PipeTransform } from "@angular/core";
import { BasketItem } from "../classes/products/BasketItem";

@Pipe({name: 'basketTotal'})
export class BasketPricePipe implements PipeTransform {
    transform(basket: Array<BasketItem>): number {
        let totalCost: number = 0;
        basket.forEach(item => {
            totalCost += item.productItem.price * item.productCount;
        });
        return totalCost;
    }
}