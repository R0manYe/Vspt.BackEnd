import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { __values } from 'tslib';
import { NgModule, Component, ViewChild, enableProdMode} from '@angular/core';
import {HttpClient, HttpClientModule, HttpHeaders, HttpParams} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService } from 'src/app/services/shared-api.service';
import { DxDataGridModule,  DxDataGridComponent,  DxListComponent,DxSelectBoxModule} from 'devextreme-angular';
import { environment } from 'src/environments/environment';


const UrlRead=environment.api+':5050/api/DailyReportingPlansDetails/read?userId='+ localStorage.getItem('username')
const URL = environment.api+':5050/api/DailyReportingPlansDetails/read?userId=';

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

      load: async () => shared.getPost(URL + localStorage.getItem('username')),  
     
      insert:async (values)=> shared.AddValue(values,URL),

      update: async (key,values)=>shared.UpdateValue(key,values,URL), 
     
      remove: async (key) => shared.DeleteValue(key,URL),
      
    })
   
    this.lookupOgrSourse = AspNetData.createStore({
      key: 'id', loadMode:'raw',loadMethod:'Post',
      loadUrl: `${environment.api+':5050/api/Filters/filterUserOrg?userId='+localStorage.getItem('username')}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });

    this.lookupCargoSourse = AspNetData.createStore({
      key: 'id', loadMode:'raw',loadMethod:'Get',
      loadUrl: `${environment.api+':5051/api/Flagman/cargo/vspt_spr_cargo_group'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });

    this.dataFilialsSourse = AspNetData.createStore({ 
      key: 'id', loadMode:'raw',loadMethod:'Post',
      loadUrl: `${environment.api+':5050/api/Filters/filterUserFilialsIdName?userId='+localStorage.getItem('username')}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });
      
  }
}
