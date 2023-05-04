import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-all-claims',
  templateUrl: './all-claims.component.html',
  styleUrls: ['./all-claims.component.css']
})
export class AllClaimsComponent implements OnInit {

  claims: any;
  constructor(private service: ClaimService, private router: Router) { }

  ngOnInit(): void {
    setTimeout(() => {
      this.getAllClaims();
    }, 7000);
    
  }

  public getAllClaims(){
    this.service.getAllClaims().subscribe((result)=>{
      this.claims = result;
    })
  }

  public updateClaims(id: number){
    this.router.navigateByUrl(`updateclaims/${id}`);
  }

  public deleteClaim(id: number){
    this.service.deleteClaim(id).subscribe((result)=>{
      console.log(result);
      this.ngOnInit();
    })
  }
}
