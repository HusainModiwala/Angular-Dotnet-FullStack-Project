import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DatePipe } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AllClaimsComponent } from './components/all-claims/all-claims.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddClaimsComponent } from './components/add-claims/add-claims.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { LoginUserComponent } from './components/login-user/login-user.component';
import { UpdateClaimComponent } from './components/update-claim/update-claim.component';
import { HomeComponent } from './components/home/home.component';
import { AdminComponentComponent } from './components/admin-component/admin-component.component';
import { ApproveFormComponent } from './components/approve-form/approve-form.component';
import { FilterPipe } from './filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    AllClaimsComponent,
    AddClaimsComponent,
    RegisterUserComponent,
    LoginUserComponent,
    UpdateClaimComponent,
    HomeComponent,
    AdminComponentComponent,
    ApproveFormComponent,
    FilterPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
