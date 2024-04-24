import { MatDialog } from '@angular/material/dialog';
import { Injectable } from '@angular/core';
import {  CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LoginComponent } from '../Auth/login/login.component';
import { ToastService } from 'src/app/services/toast.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router, private readonly toastService: ToastService, private _dialog: MatDialog){}
  canActivate():boolean{
    if(this.auth.isLoggeredIn()){
    return true;
  }else{
    this.toastService.error("ERROR")
    this._dialog.open(LoginComponent)    
    return false;
  }
  }
}
  

