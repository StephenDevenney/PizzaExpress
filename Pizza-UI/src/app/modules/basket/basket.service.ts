import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from '../../shared/classes/configuration/globals';
import { BasketItem } from '../../shared/classes/products/BasketItem';

@Injectable()
export class BasketService {

    constructor(private globals: Globals,
                private http: HttpClient){}
                
    public async getBasket(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "basket/basket-products").toPromise();
    } 
    
    public async removeFromBasket(basket: BasketItem): Promise<any> {
        return await this.http.request('delete', this.globals.config.appApiUrl + "basket/remove-product", { body: JSON.stringify(basket) }).toPromise();
    } 
    
    public async confirmOrder(basket: Array<BasketItem>): Promise<any> {
        return await this.http.post(this.globals.config.appApiUrl + "order/create-order", JSON.stringify(basket)).toPromise();
    } 
}