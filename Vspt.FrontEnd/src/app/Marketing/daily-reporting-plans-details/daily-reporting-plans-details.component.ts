import { DataSource } from '@angular/cdk/collections';
import { UserStoreService } from './../../services/user-store.service';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { __values } from 'tslib';
import { NgModule, Component, ViewChild, enableProdMode} from '@angular/core';
import {HttpClient, HttpClientModule, HttpHeaders, HttpParams} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService } from 'src/app/services/shared-api.service';
import { DxAutocompleteModule } from 'devextreme-angular';
import { Column } from 'devextreme/ui/data_grid';
import { DxDataGridModule,  DxDataGridComponent,  DxListComponent,DxSelectBoxModule} from 'devextreme-angular';




let baseURL='https://localhost:7172/api/'
let sURL='DailyReportingPlansDetails'
const UrlRead='/read?userId='
const URL = baseURL+sURL;

@Component({
  selector: 'app-daily-reporting-plans-details',
  templateUrl: './daily-reporting-plans-details.component.html',
  styleUrls: ['./daily-reporting-plans-details.component.scss']
})
export class DailyReportingPlansDetailsComponent {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent | undefined;
  @ViewChild(DxListComponent, { static: false }) list: DxListComponent | undefined;
  dataSource: any;
  dataClaim:any;
  dataUser:any;
  sprSvod:any; 
  
  lookupOgrSourse={};
  lookupCargoSourse={};
  filials = {};
  dataFilialsSourse = this.filials;
  now: Date = new Date();  

  constructor(private shared: SharedApiService) {
      
    this.dataSource = new CustomStore({   
      
                    
      key: 'id',            

      load: async () => shared.getPost(URL+UrlRead+localStorage.getItem('username')),  
     
      insert:async (values)=> shared.AddValue(values,URL),

      update: async (key,values)=>shared.UpdateValue(key,values,URL), 
     
      remove: async (key) => shared.DeleteValue(key,URL),
      
    })
   
    this.lookupOgrSourse = AspNetData.createStore({
      key: 'id', loadMode:'raw',loadMethod:'Post',
      loadUrl: `${'https://localhost:7172/api/Filters/filterUserOrg?userId='+localStorage.getItem('username')}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });

    this.lookupCargoSourse = AspNetData.createStore({
      key: 'id', loadMode:'raw',loadMethod:'Get',
      loadUrl: `${'https://localhost:7201/api/Flagman/cargo/vspt_spr_cargo_group'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });

    this.dataFilialsSourse = AspNetData.createStore({ 
      key: 'id', loadMode:'raw',loadMethod:'Post',
      loadUrl: `${'https://localhost:7172/api/Filters/filterUserFilialsIdName?userId='+localStorage.getItem('username')}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });
      
  }
}
