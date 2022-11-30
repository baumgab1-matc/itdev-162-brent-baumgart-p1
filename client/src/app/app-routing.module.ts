import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CreateItemComponent } from './components/create-item/create-item.component';
import { CreateProfileComponent } from './components/create-profile/create-profile.component';
import { EditItemComponent } from './components/edit-item/edit-item.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path : 'profile/:id', component: ProfileComponent},
  {path : 'cart', component: CartComponent},
  {path : 'edit-item/:gradId/:itemId', component: EditItemComponent},
  {path : 'create-item/:gradId', component: CreateItemComponent},
  {path : 'create-profile', component: CreateProfileComponent},
  {path : '**', redirectTo: 'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
