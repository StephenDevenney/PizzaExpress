import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/configuration/globals';

@Injectable()
export class DashboardService {

    constructor(private globals: Globals,
                private http: HttpClient){}
                
                
}