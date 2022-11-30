import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grad } from '../interfaces/grad';
import { Item } from '../interfaces/item';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class GradService {
  private apiGradUrl = 'http://localhost:5223/api/grads/';

  constructor(private http: HttpClient, private router: Router) { }

   getGrads(): Observable<Grad[]> {
      return this.http.get<Grad[]>(this.apiGradUrl);
   }

   getGradById(id: string): Observable<Grad>{
      return this.http.get<Grad>(this.apiGradUrl + id)
   }

   addNewGradProfile(grad: Grad) {
      this.http.post(this.apiGradUrl, grad).subscribe(
         response => { this.router.navigate(["/"])  },
         error => { console.log(error)}
       );       
   }

   deleteGradProfile(gradId: string) {
      this.http.delete<Item>(this.apiGradUrl + gradId).subscribe(
         response => { this.router.navigate(["/", gradId]) },
         error => { console.log(error)}
       )
   }

}
