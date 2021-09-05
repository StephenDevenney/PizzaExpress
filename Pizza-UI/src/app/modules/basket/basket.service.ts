import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class BasketService {

    constructor(private globals: Globals,
                private http: HttpClient){}
                
                
}