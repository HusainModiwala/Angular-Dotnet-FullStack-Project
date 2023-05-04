import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  loginUserForm: any
  jwtToken: any
  isApprover: any;
  error: boolean = false;
  constructor(private service: ClaimService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.init();
  }

  public loginUser(){
    this.service.loginUser(this.loginUserForm.value).subscribe((result)=>{
      console.log(result);
      if(result.responseCode == 1){
        this.error = false;
        localStorage.setItem("token", JSON.stringify(result.dataSet.token));
        if(result.dataSet.isapp){
          localStorage.setItem("isApprover", JSON.stringify(result.dataSet.isapp));
        }
        if(JSON.parse(localStorage.getItem("isApprover") ||'{}') === true){
          this.router.navigateByUrl('admin-page');
        } else{
          this.router.navigateByUrl('allclaims');
        }
      }
      else{
        console.warn('Invalid credentials');
        this.error = true;
      }
    }, error=>{
      console.warn("error", error);
    });
  
}
  private init(): void{
    this.loginUserForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get email() {return this.loginUserForm.get('email');}
  get password() {return this.loginUserForm.get('password')}

  close(){
    this.error = false;
  }
}
