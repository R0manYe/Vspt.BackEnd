import { UserStoreService } from './../../services/user-store.service';

import { DataSource } from '@angular/cdk/collections';
import { __values } from 'tslib';
import {Component, enableProdMode} from '@angular/core';
import {HttpClient, HttpClientModule, HttpHeaders, HttpParams} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService} from 'src/app/services/shared-api.service';
import { Column } from 'devextreme/ui/data_grid';

if (!/localhost/.test(document.location.host)) {
  enableProdMode();
}
let baseURL='http://backendapi:7172/v1/vspt-flagman/sprDislokaciaFiltr?userId='

@Component({
  selector: 'app-dislokacia',
  templateUrl: './dislokacia.component.html',
  styleUrls: ['./dislokacia.component.scss']
})
export class DislokaciaComponent {
  dataSource: any;
  constructor(private http: HttpClient,private shared: SharedApiService) {
    
    
    this.dataSource = new CustomStore({
                   
      
      load: async () => shared.getPost(baseURL+localStorage.getItem('username'))    
     
     
    })       
   
  }  
  setDataValue(this: Column, newData : any, value: number, currentRowData: any) {
    newData.id = null;
    defaultSetCellValue(newData, value, currentRowData);
  }
}  
   

function defaultSetCellValue(newData: any, value: number, currentRowData: any) {
  throw new Error('Function not implemented.');
}