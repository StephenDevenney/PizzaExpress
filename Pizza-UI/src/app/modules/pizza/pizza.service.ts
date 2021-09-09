import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasketItem } from '../../shared/classes/products/BasketItem';
import { Globals } from '../../shared/classes/configuration/globals';

@Injectable()
export class PizzaService {

    constructor(private globals: Globals,
                private http: HttpClient){}
                
    public async getPizza(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "products/pizza").toPromise();
    }

    public async addProductToBasket(basketItem: BasketItem): Promise<any> {
        return await this.http.post(this.globals.config.appApiUrl + "basket/add-product", JSON.stringify(basketItem)).toPromise();
    }
}