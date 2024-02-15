import { DataSource } from '@angular/cdk/collections';
import { AuthService } from './services/auth.service';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './Auth/login/login.component';
import { Router, RouterLink } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CustomStore } from 'devextreme-aspnet-data-nojquery';
import { SharedApiService } from './services/shared-api.service';

let baseURL='https://localhost:7172/api/Claims/readMenuClaim?userId=';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'VsptFrontend';
  router: any;
  dialog: any;
  dataSource:any;
  dataSourceMenu:any;
  constructor(private _dialog: MatDialog, private auth: AuthService,private route:Router,private shared: SharedApiService){
   
  }
  openDialogloginForm(){
    this._dialog.open(LoginComponent);      
  } 
  openRoute(){
    console.log(this.route.url) 
    return this.route.url; 
        
  } 
  signOut(){
    localStorage.clear();
    this.route.navigateByUrl("login")   
  }
  
   
}
