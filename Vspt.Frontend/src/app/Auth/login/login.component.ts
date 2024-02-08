
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import{FormBuilder,FormControl,FormGroup, Validators } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';

import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  hide=true;
  type: string="password"
  isText: boolean=false;
  eyeIcon: string="fa-eye-slash";
  
  
  loginForm!: FormGroup;
  signupForm!: FormGroup;
  
  constructor(
    private fb: FormBuilder, 
    private auth: AuthService, 
    private router: Router,
    private readonly toastService: ToastService,
    private userStore: UserStoreService,
    private route: ActivatedRoute,
    private dialog:MatDialog
    
    ){}  
     
ngOnInit():void{
  this.loginForm=this.fb.group({
  username: ['',Validators.required],
  password:['',Validators.required],
  openDialogloginForm(){}
})

}
openDialogloginForm(){
  this.dialog.open(LoginComponent);}  

onLogin(){
if(this.loginForm.valid){
  console.log(this.loginForm.value)
  this.auth.login(this.loginForm.value)
  .subscribe({
    next:(res)=>{
      console.log(res.message)
      this.loginForm.reset();
      this.auth.storeToken(res.accessToken);
      this.auth.storeRefreshToken(res.refreshToken);
      this.auth.storeUserName(res.username)      
      let tokenPayload=this.auth.decodeToken();

      this.userStore.setFullNameForStore(tokenPayload.unique_name);
      this.userStore.setRoleForStore(tokenPayload.role);
      
      this.toastService.success("Вы успешно авторизовались")      
      this.router.navigate(['main'])
    },
    error:(err)=>{
          this.toastService.error("Ошибка авторизации")
    }
  })
}
else
{
  console.log("Form is not valid")
  ValidateForm.validateAllFormFields(this.loginForm);
  alert("Your form is invalid")
}
}

private validateAllFormFileds(formGroup:FormGroup){
  Object.keys(formGroup.controls).forEach(field=>{
    const control=formGroup.get(field);
    if(control instanceof FormControl) {
      control.markAsDirty({ onlySelf: true });
    } else if (control instanceof FormGroup) {
      this.validateAllFormFileds(control)
    }
    
  })
}

}
