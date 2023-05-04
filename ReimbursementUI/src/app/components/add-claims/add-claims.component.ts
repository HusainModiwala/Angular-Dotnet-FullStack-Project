import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-add-claims',
  templateUrl: './add-claims.component.html',
  styleUrls: ['./add-claims.component.css']
})
export class AddClaimsComponent implements OnInit {
  claimForm: any;
  constructor(private router: Router, private formBuilder: FormBuilder, private service: ClaimService) { }

  ngOnInit(): void {
    this.init();
  }

  public addClaim(){
    console.log(this.claimForm.value);
    this.service.addClaims(this.claimForm.value).subscribe((result)=>{
      console.log(result);
    });
    setTimeout(()=>{
      this.router.navigateByUrl('allclaims');
    }, 1000)
  }

  private init(): void{
    this.claimForm = this.formBuilder.group({
      date: ['', Validators.required],
      reimbursementType: [''],
      requestedValue: ['', Validators.required],
      currency: [],
      receiptUrl:[],
      receiptAttached: [false]
    });
  }

  get date() {return this.claimForm.get('date');}
  get requestedValue() {return this.claimForm.get('requestedValue')}
  get receiptUrl() {return this.claimForm.get('receiptUrl')}

  back(){
    this.router.navigateByUrl('allclaims');
  }
}
