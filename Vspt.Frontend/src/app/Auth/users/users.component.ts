import {Component, enableProdMode} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { SharedApiService } from 'src/app/services/shared-api.service';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

let baseURL='http://backendapi:7172/api/'
let sURL='User/'
const URL = baseURL+sURL;

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {
  dataSource: any; 
  lookupUserSource: any;
 
  constructor(private http: HttpClient,private shared: SharedApiService) {
    
    this.dataSource = new CustomStore({    
      key: 'username',               
      
      load: async () => shared.getAll(URL+'read'),
     
      insert:async (values)=> shared.AddValue(values,URL),

      update: async (key,values)=>shared.UpdateValue(key,values,URL), 
     
      remove: async (key) => shared.DeleteValue(key,URL)
    })
    
    this.lookupUserSource = AspNetData.createStore({
      key: 'id', loadMode:'raw',
      loadUrl: `${'http://localhost:7201/api/Flagman/vspt_subject_persone_id_name'}`,
      onBeforeSend(method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
      },
    });
  }
}
