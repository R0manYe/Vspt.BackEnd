import { MatDialog } from '@angular/material/dialog';
import { NgToastService } from 'ng-angular-popup';
import { Injectable } from '@angular/core';
import {  CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LoginComponent } from '../Auth/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router, private toast: NgToastService, private _dialog: MatDialog){}
  canActivate():boolean{
    if(this.auth.isLoggeredIn()){
    return true;
  }else{
    this.toast.error({detail:"ERROR", summary:"Please login first!"})
    this._dialog.open(LoginComponent)
    // this.router.navigate(['login'])
    return false;
  }
  }
}
  

