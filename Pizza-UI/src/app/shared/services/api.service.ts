import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';
import { Config } from '../classes/configuration/config';
import { Globals } from '../classes/configuration/globals';
import { AuthService } from './auth.service';

@Injectable()
export class APIService {
    constructor(private globals: Globals,
                private http: HttpClient,
                private authService: AuthService) {}

    public async loadApplication(): Promise<any> {
        return await this.http.get('/assets/appsettings.json')
                        .pipe(map((res: any) => res))
                        .pipe(switchMap(async (res: Config) => {
                            this.globals.config.hubName = res.hubName;
                            this.globals.config.appApiUrl = res.appApiUrl;
                            this.globals.config.authApiUrl = res.authApiUrl;
                            this.globals.config.securityRedirectUrl = res.securityRedirectUrl;
                            this.globals.config.defaultPage = res.defaultPage;
                            this.globals.config.basketPage = res.basketPage;
                            this.globals.currentPage = res.defaultPage;
                            
                            if(!this.authService.hasAuthToken()) {
                                return this.globals;
                            }
                            else
                                return await this.http.get(this.globals.config.appApiUrl + "security/client").pipe(map(r => r)).toPromise();     
                        })).toPromise().catch((err: any) => {
                             this.globals.seriousErrorMessage = err;
                        }).then((res: any) => {
                            if(this.globals.seriousErrorMessage == "") {
                                if(res.isAuthenticated) {
                                    this.globals.isSignedIn = true;
                                    this.globals.client.clientName = res.clientName;
                                    this.globals.client.clientRole = res.clientRole;
                                    this.globals.client.isAuthenticated = res.isAuthenticated;
                                }
                                else
                                    this.authService.signOut();
                            }
                            else
                                this.authService.signOut();
                        });
    }
}

