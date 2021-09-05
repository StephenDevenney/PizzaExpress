import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Globals } from '../classes/globals';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast'
import { MessageService } from 'primeng/api';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { ButtonModule } from 'primeng/button';
import { PageModule } from 'src/app/layout/page/page.module';
import { PageComponent } from 'src/app/layout/page/page.component';

@NgModule({
  imports: [
    CommonModule,
    PageModule,
    NgxUiLoaderModule,
    ButtonModule
  ],
  declarations: [
    
  ],
  exports: [
    PageComponent,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ToastModule,
    ButtonModule
  ],
  providers: [
    Globals,
    MessageService
  ]
})
export class SharedModule { 
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule
    }
  }
}
