import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast'
import { MessageService } from 'primeng/api';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { LayoutModule } from 'src/app/layout/layout.module';
import { Globals } from '../classes/configuration/globals';

@NgModule({
  imports: [
    CommonModule,
    NgxUiLoaderModule,
    ButtonModule,
    LayoutModule
  ],
  declarations: [
    
  ],
  exports: [
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ToastModule,
    ButtonModule,
    LayoutModule
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
