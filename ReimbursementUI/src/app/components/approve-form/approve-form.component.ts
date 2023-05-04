import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-approve-form',
  templateUrl: './approve-form.component.html',
  styleUrls: ['./approve-form.component.css']
})
export class ApproveFormComponent implements OnInit {
  updateForm: any;
  constructor(private dp: DatePipe, private route: Router, private formBuilder: FormBuilder, private service: ClaimService, private ar: ActivatedRoute) { }
  dat: any;
  ngOnInit(): void {
    this.init();
  }

  public updateClaim(){
    console.log(this.updateForm.value);
    this.service.updateClaims(this.updateForm.value, this.ar.snapshot.params['id']).subscribe((result)=>{
      console.log(result);
    });
    this.route.navigateByUrl('admin-page');
  }

  init(){
    this.service.getClaimById(this.ar.snapshot.params['id']).subscribe((res:any)=>{
      this.updateForm = this.formBuilder.group({
        date: [this.dp.transform(res['date'], 'yyyy-MM-dd'), Validators.required],
        reimbursementType: [res['reimbursementType'], Validators.required],
        requestedValue: [res['requestedValue'], Validators.required],
        currency: [res['currency'], Validators.required],
        receiptAttached: [res['receiptAttached'], Validators.required],
        approvedValue: [res['approvedValue'], Validators.required],
        requestPhase: [res['requestPhase'], Validators.required],
        email:[res['email'], Validators.required],
        userId:[res['userId'], Validators.required],
        internalNotes: [],
        approvedBy:['', Validators.required]
      })
    })
  }
  get approvedValue() {return this.updateForm.get('approvedValue');}
  get approvedBy() {return this.updateForm.get('approvedBy')}
  get requestPhase() {return this.updateForm.get('requestPhase')}

  back(){
    this.route.navigateByUrl('admin-page');
  }
}
