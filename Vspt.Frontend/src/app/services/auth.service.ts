import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import {HttpClient} from"@angular/common/http";
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenApiModel } from '../models/token-api.model';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private baseUrl:string=environment.api+":5050/api/User/";
  private userPlayload : any;
  constructor(private http : HttpClient,private router: Router) {
    this.userPlayload=this.decodeToken();
   }

  signUp(userObj:any)
  {
    return this.http.post<any>(`${this.baseUrl}register`,userObj)

  }
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}authenticate`,loginObj)
  }
  
  signOut(){
    localStorage.clear();
    this.router.navigate(['login'])    
  }

  storeToken(tokenValue: string)
  {
    localStorage.setItem('accessToken', tokenValue)
  }
  storeRefreshToken(tokenValue: string)
  {
    localStorage.setItem('refreshToken', tokenValue)
  }
  storeUserName(tokenValue: string)
  {
    localStorage.setItem('username', tokenValue)
  }

  getToken()
  {
    return localStorage.getItem('accessToken')
  }
  getRefreshToken()
  {
    return localStorage.getItem('refreshToken')
  }
  getUserName()
  {
    return localStorage.getItem('username')
  }

  isLoggeredIn(): boolean{
    return !!localStorage.getItem('accessToken')
  }

  decodeToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }

  getfullNameFromToken(){
    if(this.userPlayload)
    return this.userPlayload.unique_name;
  }
  
  getRoleFromToken(){
    if(this.userPlayload)
    return this.userPlayload.role;
  }

  renewToken(tokenApi:TokenApiModel)
  {
    return this.http.post<any>(`${this.baseUrl}refresh`, tokenApi)
  }
}
