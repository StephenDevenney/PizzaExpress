import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { DashboardComponent } from './dashboard-page/dashboard.component';
import { DashboardService } from './dashboard.service';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    DashboardService
  ]
})

export class DashboardModule { 
  static forRoot(): ModuleWithProviders<DashboardModule> {
    return {
      ngModule: DashboardModule
    }
  }
}
