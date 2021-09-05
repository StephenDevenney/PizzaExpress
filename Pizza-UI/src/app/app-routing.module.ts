import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BasketComponent } from './modules/basket/basket-page/basket.component';
import { DashboardComponent } from './modules/dashboard/dashboard-page/dashboard.component';
import { OrdersComponent } from './modules/orders/orders-page/orders.component';
import { PizzaComponent } from './modules/pizza/pizza-page/pizza.component';
import { SignInComponent } from './modules/sign-in/sign-in-page/signin.component';

const routes: Routes = [
  { path: 'sign-in', component: SignInComponent, data: {page: 'sign-in'} },
  { path: 'dashboard', component: DashboardComponent, data: {page: 'dashboard'} },
  { path: 'pizza', component: PizzaComponent, data: {page: 'pizza'} },
  { path: 'basket', component: BasketComponent, data: {page: 'basket'} },
  { path: 'orders', component: OrdersComponent, data: {page: 'orders'} },
  { path: '**', redirectTo:'sign-in', data: {page: 'sign-in'} }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
