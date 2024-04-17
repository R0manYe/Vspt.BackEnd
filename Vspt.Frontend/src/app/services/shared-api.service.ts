import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class SharedApiService {

 
  constructor(private http: HttpClient){}
  
     getAll(URL:string){
      return this.http.get(URL).toPromise();      
    }
    getPost(URL:string){
      return this.http.post(URL, {
        headers: new HttpHeaders({
          'Accept': '',
          'Content-Type': ' application/json; charset=utf-8'
        }),
        responseType: 'text'
      })
     
          .toPromise()
          .catch(() => { throw 'Insertion failed' });
  };     
   
    AddValue(values:object,URL:string){
      return this.http.post(URL+'add',values, {
        headers: new HttpHeaders({
          'Accept': '',
          'Content-Type': ' application/json; charset=utf-8'
        }),
        responseType: 'text'
      })
     
          .toPromise()
          .catch(() => { throw 'Insertion failed' });
  };
    InsertValue(key:string,values:object,URL:string)
    { 
      return this.http.put(URL+'update/'+key,(values), {
        headers: new HttpHeaders({
          'Accept': '*/*',
          'Content-Type': 'application/json; charset=utf-8'
        }),
        responseType: 'text'
      })                
          .toPromise()
          .catch(() => { throw 'Update failed' });
     }
     UpdateValue(key:string,values:object,URL:string)
     { 
       return this.http.put(URL+'/update/'+key,(values), {
         headers: new HttpHeaders({
           'Accept': '*/*',
           'Content-Type': 'application/json; charset=utf-8'
         }),
         responseType: 'text'
       })                
           .toPromise()
           .catch(() => { throw 'Update failed' });
      }
     DeleteValue(key:string,URL:string)
     {
      return this.http.delete<any>(URL+'delete/'+ key)
      .toPromise()         
      
    }

    getSprCargo(URL:string){
      return this.http.post('https://localhost:7201/api/Flagman/cargo/vspt_spr_cargo/', {
        headers: new HttpHeaders({
          'Accept': '',
          'Content-Type': ' application/json; charset=utf-8'
        }),
        responseType: 'text'
      })
     
          .toPromise()
          .catch(() => { throw 'Insertion failed' });
  };
    
}
