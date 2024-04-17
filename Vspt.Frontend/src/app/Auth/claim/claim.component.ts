import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import { __values } from 'tslib';
import { NgModule, Component, ViewChild, enableProdMode} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService } from 'src/app/services/shared-api.service';
import {  DxDataGridComponent} from 'devextreme-angular';
import { ClaimApiModel,ClaimModel } from 'src/app/models/claim-api.models';

if (!/backendapi/.test(document.location.host)) {
  enableProdMode();
}
let baseURL='http://backendapi:7172/api/'
let sURL='Claims/'
const URL = baseURL+sURL;
const bURL='http://backendapi:7172/api/Claims/readClaimType';
@Component({
  selector: 'claim',
  templateUrl: './claim.component.html',
  styleUrls: ['./claim.component.scss'],
   
})

export class ClaimComponent {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent | undefined;
  dataSource: any; 

  lookupUserSource={};
  lookupClaimType:any;
  lookupSprSvod:any;
  row:any;
  focusedRowKey=1;
  constructor(private shared: SharedApiService,private http:HttpClient) {
  
   this.dataSource = new CustomStore({   
                    
      key: 'id',               

      load: async () => shared.getAll(URL+'read'),
     
      insert:async (values)=> shared.AddValue(values,URL),

      update: async (key,values)=>shared.UpdateValue(key,values,URL), 
     
      remove: async (key) => shared.DeleteValue(key,URL)
    })    
  
  this.lookupUserSource = AspNetData.createStore({
      key: 'id', loadMode:'raw',
      loadUrl: `${'https://backendapi:7201/api/Flagman/vspt_subject_persone_id_name'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });

    this.lookupClaimType = AspNetData.createStore({
      key: 'id', loadMode:'raw',
      loadUrl: `${'http://backendapi:7172/api/Claims/readClaimType'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    })
    this.lookupSprSvod = AspNetData.createStore({
      key: 'id', loadMode:'raw',
      loadUrl: `${'http://backendapi:7172/api/Source/readSprSvod'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    })
 
    this.getFilteredSprSvod=this.getFilteredSprSvod.bind(this);  
    
  }
  
  getFilteredSprSvod(options:any) {
    return {
      store: this.lookupSprSvod,
      filter: options.data ? ['spr', '=', options.data.claimName] : null,
    };
  }
  onEditorPreparing(e:any) {
    if (e.parentType === 'dataRow' && e.dataField === 'claimValue') {
      const isStateNotSet = e.row.data.claimName === undefined;

      e.editorOptions.disabled = isStateNotSet;
    }
  }
  
  setClaimValue(this: any, newData: ClaimModel, value: number, currentRowData: ClaimModel) {
    newData.claimValue == null;
    this.defaultSetCellValue(newData, value, currentRowData);
  }  
}