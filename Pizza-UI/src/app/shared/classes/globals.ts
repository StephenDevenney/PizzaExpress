import { Injectable } from '@angular/core';
import { Config } from './config';
import { NavPage } from './nav.page';
import { Client } from './client';

@Injectable()
export class Globals {
    public config: Config = new Config;
    public client: Client = new Client;
    public isSignedIn: boolean = false;
    public seriousErrorMessage: string = "";
    public previousPage: NavPage = new NavPage;
    public currentPage: NavPage = new NavPage;
}