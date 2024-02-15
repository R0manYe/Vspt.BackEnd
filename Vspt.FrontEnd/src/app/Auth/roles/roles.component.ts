import { DataSource } from '@angular/cdk/collections';
import { __values } from 'tslib';
import {Component, ViewChild, enableProdMode} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService } from 'src/app/services/shared-api.service';
import { RoleModel } from 'src/app/models/role.models';
import { DxDataGridComponent } from 'devextreme-angular';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

if (!/localhost/.test(document.location.host)) {
  enableProdMode();
}
let baseURL='https://localhost:7172/api/'
let sURL='Roles/'
const URL = baseURL+sURL;


@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent { 
  
  dataSource: any; 
  
  taskEmployees: any;


  constructor(private http: HttpClient,private shared: SharedApiService) {
    
    this.dataSource = new CustomStore({    
                 
      key:'id',
      load: async () => shared.getAll(URL+'read'),
     
      insert:async (values)=> shared.AddValue(values,URL),

      update: async (key,values)=>shared.UpdateValue(key,values,URL), 
     
      remove: async (key) => shared.DeleteValue(key,URL)
    })
  }
}

