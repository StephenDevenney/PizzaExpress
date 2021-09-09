import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '../../../shared/components/base.component';
import { DashboardService } from '../dashboard.service';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent extends BaseComponent implements OnInit {
  
  public isLoaded: boolean = false;

  constructor(private injector: Injector,
              private dashboardService: DashboardService) {
    super(injector);
  }

  ngOnInit(): void {
    this.isLoaded = true;
  }
}
