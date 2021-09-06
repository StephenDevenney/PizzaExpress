import { Injectable } from '@angular/core';
import { NavPage } from './nav.page';

@Injectable()
export class Config {
    public hubName: string = "";
    public appApiUrl: string = "";
    public authApiUrl: string = "";
    public securityRedirectUrl: string = "";
    public defaultPage: NavPage = new NavPage;
    public basketPage: NavPage = new NavPage;
}


