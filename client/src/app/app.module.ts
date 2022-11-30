import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { CartComponent } from './components/cart/cart.component';
import { EditItemComponent } from './components/edit-item/edit-item.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreateItemComponent } from './components/create-item/create-item.component';
import { CartItemComponent } from './components/cart-item/cart-item.component';
import { CreateProfileComponent } from './components/create-profile/create-profile.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ProfileComponent,
    HomeComponent,
    CartComponent,
    EditItemComponent,
    CreateItemComponent,
    CartItemComponent,
    CreateProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
