import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../shared/components/base.component';
import { PageService } from '../page.service';
import { NavPage } from 'src/app/shared/classes/nav.page';
import { SharedService } from 'src/app/shared/services/shared.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav.component.html'
})
export class NavComponent extends BaseComponent implements OnInit {
  public navigationMenu: Array<NavPage> = new Array<NavPage>();
  public navLoaded: boolean = false;

  constructor(private injector: Injector,
    private pageService: PageService,
    private sharedService: SharedService) {
    super(injector);
   }

  async ngOnInit(): Promise<void> {
    await this.pageService.getNavMenu().then((res: Array<NavPage>) => {
      this.navigationMenu = res;
      this.navLoaded = true;
    }).catch((err: any) => {
      // Log Error
    });
  }

  public async navToPage(navMenu: NavPage) {
    this.sharedService.navToPage(navMenu); 
  }
}
