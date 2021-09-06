import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutService } from './layout.service';
import { NavComponent } from './nav/nav.component';
import { PageComponent } from './page/page.component';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ToastModule } from 'primeng/toast';
import { PageHeaderComponent } from './page/page-header/page-header.component';
import { RippleModule } from 'primeng/ripple';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ToastModule,
    InputSwitchModule,
    ButtonModule,
    RippleModule
  ],
  declarations: [
    PageComponent,
    NavComponent,
    PageHeaderComponent
  ],
  exports: [
    PageComponent,
    NavComponent,
    PageHeaderComponent,
    RippleModule
  ],
  providers: [
    LayoutService
  ]
})
export class LayoutModule { 
  static forRoot(): ModuleWithProviders<LayoutModule> {
    return {
      ngModule: LayoutModule
    }
  }
}
