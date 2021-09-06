import { Component, Injector, Input, OnInit } from '@angular/core';
import { HeaderType } from '../enums/header-type';
import { BaseComponent } from '../../../shared/components/base.component';
import { NavPage } from '../../../shared/classes/nav.page';
import { SharedService } from 'src/app/shared/services/shared.service';
import { TestBed } from '@angular/core/testing';

@Component({
  selector: 'page-header',
  templateUrl: './page-header.component.html'
})
export class PageHeaderComponent extends BaseComponent implements OnInit {

  @Input() pageTitle: string = "";
  @Input() subTitle1: string = "";
  @Input() subTitle2: string = "";
  @Input() pageHint: string = "";
  @Input() headerType: HeaderType = HeaderType.Short;
  @Input('showback') showBackButton: boolean = false;
  public showOptions: boolean = false;
  public showSideOptions: boolean = false;
  public sideOptionsId: number = 0;

  constructor(private injector: Injector,
    private sharedService: SharedService) {
    super(injector);
   }

  ngOnInit(): void {
    
  }

  ngOnChanges() {
    this.pageTitle = this.pageTitle[0].toUpperCase() + this.pageTitle.substr(1).toLowerCase();
  }

  public async navToBasket(): Promise<void> {
    await this.sharedService.navToPage(this.globals.config.basketPage);
  }
}
