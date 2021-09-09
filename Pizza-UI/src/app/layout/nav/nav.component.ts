import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../shared/components/base.component';
import { LayoutService } from '../layout.service';
import { NavPage } from '../../shared/classes/configuration/nav.page';
import { SharedService } from '../../shared/services/shared.service';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav.component.html'
})
export class NavComponent extends BaseComponent implements OnInit {
  public navigationMenu: Array<NavPage> = new Array<NavPage>();
  public navLoaded: boolean = false;

  constructor(private injector: Injector,
    private layoutService: LayoutService,
    private sharedService: SharedService,
    private authService: AuthService) {
    super(injector);
   }

  async ngOnInit(): Promise<void> {
    await this.layoutService.getNavMenu().then((res: Array<NavPage>) => {
      this.navigationMenu = res;
      this.navLoaded = true;
    }).catch((err: any) => {
      // Log Error
    });
  }

  public async navToPage(navMenu: NavPage): Promise<void> {
    await this.sharedService.navToPage(navMenu); 
  }

  public async signOut(): Promise<void> {
    await this.authService.signOut();
  }
}
