import { inject, Injector } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { LoadingService } from '../services/loading.service';
import { Globals } from '../classes/configuration/globals';

export class BaseComponent {
    public globals: Globals;
    public location: Location;
    public router: Router;
    public messageService: MessageService;
    public loader: LoadingService;

    constructor(injector: Injector) {
        this.globals = injector.get(Globals);
        this.location = injector.get(Location);
        this.router = injector.get(Router);
        this.messageService = injector.get(MessageService);
        this.loader = injector.get(LoadingService);
    }
}