import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';


import { LoginComponent } from './Auth/login/login.component';
import { MainComponent } from './main/main.component';
import { DislokaciaComponent } from './Marketing/dislokacia/dislokacia.component';
import { SignupComponent } from './Auth/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';
import { ClaimComponent } from './Auth/claim/claim.component';

import { RolesComponent } from './Auth/roles/roles.component';
import { UsersComponent } from './Auth/users/users.component';

import { DailyReportingPlansDetailsComponent } from './Marketing/daily-reporting-plans-details/daily-reporting-plans-details.component';

const routes: Routes = [
{path:'',redirectTo:'login',pathMatch:'full'},

{path:'login', component:LoginComponent},
{path:'signup', component:SignupComponent},
{path:'main', component:MainComponent},

{path:'claim', component:ClaimComponent},
{path:'roles', component:RolesComponent},
{path:'users', component:UsersComponent},
{path:'dislokacia',component:DislokaciaComponent, canActivate:[AuthGuard]},
{path:'deilyreportingplandetails', component:DailyReportingPlansDetailsComponent ,canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
