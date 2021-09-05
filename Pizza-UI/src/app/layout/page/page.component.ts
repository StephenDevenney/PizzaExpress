import { Component, ContentChild, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';

@Component({
  selector: 'page',
  templateUrl: './page.component.html'
})
export class PageComponent extends BaseComponent implements OnInit {
  
  @ViewChild("pageContent") content!: ElementRef;

  constructor(private injector: Injector) { super(injector); }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    
  }

}
