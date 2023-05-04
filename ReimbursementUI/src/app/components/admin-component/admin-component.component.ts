import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ClaimService } from 'src/app/services/claim.service';

@Component({
  selector: 'app-admin-component',
  templateUrl: './admin-component.component.html',
  styleUrls: ['./admin-component.component.css']
})
export class AdminComponentComponent implements OnInit {
  claims: any = [];
  pending:any = [];
  approved:any = [];
  declined:any = [];
  declineForm: any = null;
  flag:any = false;
  declineId: any;
  loading:any = [];
  toggle: any = 1;
  searchEmail: string = '';
  constructor(private dp: DatePipe, private service: ClaimService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    setTimeout(() => {
      this.getAllClaims();
    }, 1000);
    
  }

  public getAllClaims(){
    this.service.getAllClaims().subscribe((result)=>{
      this.claims = result;
      console.log(this.claims);
    })
  }

  public segregate(): void{
    this.claims.forEach((element:any) => {
      if(element.requestPhase === 'To be processed'){
        
        this.pending.push(element);
      } else if(element.requestPhase === 'Approved'){
        this.approved.push(element);
      } else{
        this.declined.push(element);
      }
    });
  }

  public load(){
    if(this.toggle === 1){
      this.loading = this.pending;
    } else if(this.toggle === 2){
      this.loading = this.approved;
    } else{
      this.loading = this.declined;
    }
  }

  public setToggle(num: number){
    if(this.pending.length===0 && this.approved.length===0 && this.declined.length===0 && this.claims.length>0){
      this.segregate();
    }
    this.toggle = num;
    this.load();
    console.log(this.loading);
  }

  public approve(id: number){
    this.router.navigateByUrl(`approve-form/${id}`);
  }

  public decline(id: number){
    this.declineId = id;
    this.service.getClaimById(id).subscribe((res:any)=>{
      this.declineForm = this.formBuilder.group({
        date: [this.dp.transform(res['date'], 'yyyy-MM-dd')],
        reimbursementType: [res['reimbursementType']],
        requestedValue: [res['requestedValue']],
        currency: [res['currency']],
        receiptAttached: [res['receiptAttached']],
        approvedValue: [0],
        requestPhase: ['Declined'],
        email:[res['email']]
      })
    })
    setTimeout(() => {
      this.flag = true;
    }, 200);
  }

  public confirmDecline(){
    this.service.updateClaims(this.declineForm.value, this.declineId).subscribe((res)=>{
      console.log(res);
    })
    this.flag = false;
  }
}
