import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Globals } from '../../classes/configuration/globals';

@Component({
  selector: 'redirectTo',
  templateUrl: './redirectTo.component.html'
})
export class RedirectToComponent implements OnInit {

  constructor(private globals: Globals,
              private router: Router) { }

  ngOnInit(): void {
    var current_page = localStorage.getItem("current_page");
    if(current_page) 
      this.router.navigate(["/" + current_page + "/"]);
  }

}