import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-update-claim',
  templateUrl: './update-claim.component.html',
  styleUrls: ['./update-claim.component.css']
})
export class UpdateClaimComponent implements OnInit {
  updateForm: any;
  constructor(private dp: DatePipe, private route: Router, private formBuilder: FormBuilder, private service: ClaimService, private ar: ActivatedRoute) { }
  dat: any;
  ngOnInit(): void {
    this.init();
  }

  public updateClaim(){
    this.ar.snapshot.params['id']
    this.service.updateClaims(this.updateForm.value, this.ar.snapshot.params['id']).subscribe((result)=>{
      console.log(result);
    });
    this.route.navigateByUrl('allclaims');
  }

  init(){
    this.service.getClaimById(this.ar.snapshot.params['id']).subscribe((res:any)=>{
      this.dat = res['date'];
      this.dat = this.dp.transform(this.dat, 'yyyy-MM-dd');
      console.log(this.dat);
      this.updateForm = this.formBuilder.group({
        date: [this.dat, Validators.required],
        reimbursementType: [res['reimbursementType'], Validators.required],
        requestedValue: [res['requestedValue'], Validators.required],
        currency: [res['currency'], Validators.required],
        receiptAttached: [res['receiptAttached'], Validators.required],
        email:[res['email'], Validators.required],
        userId: [res['userId'], Validators.required],
        receptUrl: [res['receptUrl']]
      })
    })
  }
  back(){
    this.route.navigateByUrl('addclaims');
  }
}
