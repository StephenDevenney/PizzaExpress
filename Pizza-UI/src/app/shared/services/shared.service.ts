import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Globals } from '../classes/configuration/globals';
import { NavPage } from '../classes/configuration/nav.page';
import { AuthService } from './auth.service';

@Injectable()
export class SharedService {

    constructor(private router: Router,
                private globals: Globals,
                private titleService: Title,
                private authService: AuthService,
                private http: HttpClient){}

    public async navToPage(navMenu: NavPage): Promise<void> {
        if(navMenu.navMenuRoute != "" || navMenu.navMenuRoute != undefined) {
          await this.router.navigate([navMenu.navMenuRoute]).then(() => {
            this.titleService.setTitle(this.globals.config.hubName + " - " + navMenu.navMenuName);
            this.globals.previousPage = this.globals.currentPage;
            this.globals.currentPage = navMenu;
            this.authService.updateCurrentPage(navMenu);
          });
        }   
    }
}