import { JsonPipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root',
})
export class ClaimService {
  baseUrlClaims = 'https://localhost:44387/api/claims';
  baseUrlUsers = 'https://localhost:44387/api/user';
  token:any = JSON.parse(localStorage.getItem("token")||'{}');
  header:any = new HttpHeaders().set(
      'Authorization',
      'bearer '+this.token
    );
  constructor(private http: HttpClient) {}

  public getAllClaims(): Observable<any> {
    return this.http.get(`${this.baseUrlUsers}/GetUserClaims`,{headers: this.header});
  }

  public getClaimById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrlClaims}/getclaimbyid/${id}`,{headers: this.header});
  }

  public addClaims(claim: any): Observable<any> {
    console.log(this.header);
    return this.http.post(`${this.baseUrlClaims}/addclaim`, claim, {headers: this.header});
  }

  public updateClaims(claim: any, id: number): Observable<any> {
    console.log(this.token);
    return this.http.put(`${this.baseUrlClaims}/updateclaim/${id}`, claim, {headers: this.header});
  }

  public deleteClaim(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrlClaims}/deleteclaim/${id}`, {headers: this.header});
  }

  public registerUser(user: any): Observable<any> {
    return this.http.post(`${this.baseUrlUsers}/registeruser`, user);
  }

  public loginUser(user: any): Observable<any> {
    return this.http.post(`${this.baseUrlUsers}/loginuser`, user);
  }

  public logoutUser(){
    return this.http.get(`${this.baseUrlUsers}/logoutuser`, {headers: this.header});
  }

  public isApprover(){
    return this.http.get(`${this.baseUrlUsers}/isapprover`, {headers: this.header});
  }
}
