import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from '../../shared/classes/configuration/globals';

@Injectable()
export class OrdersService {

    constructor(private globals: Globals,
                private http: HttpClient){}
                
                
}