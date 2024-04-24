import { NgModule} from '@angular/core';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgToastModule} from 'ng-angular-popup';
import { NgConfirmModule } from 'ng-confirm-box';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { LoginComponent } from './Auth/login/login.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MainComponent } from './main/main.component';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import { DislokaciaComponent } from './Marketing/dislokacia/dislokacia.component';
import { DxDataGridModule, DxBulletModule,  DxTemplateModule, DxSelectBoxModule, DxButtonModule,DxDropDownBoxModule,DxDataGridComponent,DxListModule,DxDateBoxModule } from 'devextreme-angular';
import {MatMenuModule} from '@angular/material/menu';
import { SignupComponent } from './Auth/signup/signup.component';
import {MatTabsModule} from '@angular/material/tabs';
import { ClaimComponent } from './Auth/claim/claim.component';
import { RolesComponent } from './Auth/roles/roles.component';
import { UsersComponent } from './Auth/users/users.component';
import { DxAutocompleteModule } from 'devextreme-angular';
import { DailyReportingPlansDetailsComponent } from './Marketing/daily-reporting-plans-details/daily-reporting-plans-details.component';







@NgModule({
  declarations: [
    AppComponent,   
    LoginComponent, MainComponent, DislokaciaComponent, SignupComponent, ClaimComponent, RolesComponent, UsersComponent, DailyReportingPlansDetailsComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserTransferStateModule,
    NgToastModule,
    NgConfirmModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    MatMenuModule,
    MatTabsModule,
    DxAutocompleteModule,
    DxSelectBoxModule,
    DxButtonModule,
    DxDropDownBoxModule,
    DxListModule,
    DxDateBoxModule 
  ],
  providers: [{provide: HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true} ],
  bootstrap: [AppComponent]
})
export class AppModule { }