import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxUiLoaderModule, NgxUiLoaderConfig, POSITION, SPINNER, PB_DIRECTION } from 'ngx-ui-loader';
import { APIInterceptor } from './shared/classes/configuration/api.interceptor';
import { AuthService } from './shared/services/auth.service';
import { APIService } from './shared/services/api.service';
import { SharedModule } from './shared/modules/sharedModule';
import { RedirectToComponent } from './shared/components/redirect-to/redirectTo.component';
import { LoadingService } from './shared/services/loading.service';
import { MessageService } from 'primeng/api';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { BasketModule } from './modules/basket/basket.module';
import { OrdersModule } from './modules/orders/orders.module';
import { PizzaModule } from './modules/pizza/pizza.module';
import { SignInModule } from './modules/sign-in/signin.module';
import { SharedService } from './shared/services/shared.service';

/*
  bgs = bottomRight Small loader
  fgs = main center loader
  pb = top bar loader
*/
const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  bgsColor: '#66b3ff',
  bgsPosition: POSITION.bottomRight,
  bgsSize: 100,
  bgsType: SPINNER.wanderingCubes,
  bgsOpacity: 0.8,
  fgsColor: '#66b3ff',
  fgsPosition: POSITION.centerCenter,
  fgsType: SPINNER.cubeGrid,
  fgsSize: 150,
  pbColor: '#66b3ff',
  pbDirection: PB_DIRECTION.leftToRight,
  pbThickness: 20
};

@NgModule({
  declarations: [
    AppComponent,
    RedirectToComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SignInModule,
    DashboardModule,
    BasketModule,
    OrdersModule,
    PizzaModule,
    SharedModule,
    HttpClientModule,
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig)
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true,
    },
    APIService ,
    MessageService,
    LoadingService,
    SharedService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
