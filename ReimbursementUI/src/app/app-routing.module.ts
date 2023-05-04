import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddClaimsComponent } from './components/add-claims/add-claims.component';
import { AdminComponentComponent } from './components/admin-component/admin-component.component';
import { AllClaimsComponent } from './components/all-claims/all-claims.component';
import { ApproveFormComponent } from './components/approve-form/approve-form.component';
import { HomeComponent } from './components/home/home.component';
import { LoginUserComponent } from './components/login-user/login-user.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { UpdateClaimComponent } from './components/update-claim/update-claim.component';

const routes: Routes = [
  {path:'allclaims', component:AllClaimsComponent},
  {path:'addclaims', component:AddClaimsComponent},
  {path:'updateclaims/:id', component:UpdateClaimComponent},
  {path:'register-user', component:RegisterUserComponent},
  {path:'login-user', component:LoginUserComponent},
  {path:'admin-page', component:AdminComponentComponent},
  {path:'approve-form/:id', component:ApproveFormComponent},
  {path:'', component:HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
