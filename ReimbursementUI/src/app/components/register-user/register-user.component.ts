import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  registerUserForm: any
  constructor(private router: Router, private service: ClaimService, private formBuilder: FormBuilder,) { }

  ngOnInit(): void {
    this.init();
  }

  public registerUser(){
    this.service.registerUser(this.registerUserForm.value).subscribe((result)=>{
      console.log(result);
    });
    this.router.navigateByUrl('login-user');
  }
  
  private init(): void{
    this.registerUserForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, 
        Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/),
        Validators.minLength(8)]],
      confirmPassword: ['', Validators.required],
      fullName: ['', Validators.required],
      pan: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern(/^(?=.*[A-Z])(?=.*[0-9])/)]],
      bank: ['', Validators.required],
      bankAccNo: ['', [Validators.required, Validators.minLength(12), Validators.maxLength(12), Validators.pattern(/^(?=.*[0-9])/)]]
    },{
      validator:this.checkPass('password', 'confirmPassword')
    });
  }

  get email() {return this.registerUserForm.get('email');}
  get password() {return this.registerUserForm.get('password')}
  get fullName() {return this.registerUserForm.get('fullName')}
  get pan() {return this.registerUserForm.get('pan')}
  get bankAccNo() {return this.registerUserForm.get('bankAccNo')}
  

  checkPass(pass: string, confPass: string) {
    return (formGroup: FormGroup)=>{
      const control = formGroup.controls[pass];
      const matchControl = formGroup.controls[confPass];
      if(matchControl.errors && !matchControl.errors['confirmedValidator']){
        return
      }
      if(control.value !== matchControl.value){
        matchControl.setErrors({confirmedValidator: true});
      }
      else{
        matchControl.setErrors(null);
      }
    }
  }

  get f(){
    return this.registerUserForm.controls;
  }
}
