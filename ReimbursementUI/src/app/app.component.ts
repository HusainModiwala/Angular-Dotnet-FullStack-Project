import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ClaimService } from './services/claim.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ReimbursementUI';
  constructor(private router: Router, private service: ClaimService){}
  ifLoggedIn():boolean{
    if(localStorage.getItem('token') == null){
      return false;
    }
    return true;
  }

  logout(){
    localStorage.clear();
    this.service.logoutUser();
    this.router.navigateByUrl('');
  }

  ifAdmin(){
    if(localStorage.getItem("isApprover") !== null && JSON.parse(localStorage.getItem("isApprover") ||'{}') === true){
      return true;
    }
    return false;
  }
}
