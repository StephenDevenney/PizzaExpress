import { Injectable } from '@angular/core';
import { ClientRole } from './client.role';

@Injectable()
export class Client {
    public clientName: string = "";
    public token: string = "";
    public clientRole: ClientRole = new ClientRole;
    public isAuthenticated: boolean = false;
}


