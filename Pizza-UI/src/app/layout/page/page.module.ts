import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageComponent } from './page.component';
import { PageService } from './page.service';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ButtonModule } from 'primeng/button';

@NgModule({
  declarations: [
    PageComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ToastModule,
    InputSwitchModule,
    ButtonModule
  ],
  exports: [
    PageComponent,
  ],
  providers: [
    PageService
  ]
})
export class PageModule { 
  static forRoot(): ModuleWithProviders<PageModule> {
    return {
      ngModule: PageModule
    }
  }
}
