import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Item } from '../interfaces/item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  private apiItemUrl:string  = 'http://localhost:5223/api/items/';


  constructor(private http: HttpClient, private router: Router) { }

  addItem(item: Item): void {
    this.http.post(this.apiItemUrl, item).subscribe(
      response => { this.router.navigate(["/profile/", item.gradId])  },
      error => { console.log(error)}
    );
  }

  getItemById(itemId: String): Observable<Item> {
    return this.http.get<Item>(this.apiItemUrl + itemId);
 }


  updateItem(updateItem: Item): void {
    console.log(updateItem);
    this.http.put<Item>(this.apiItemUrl + updateItem.id, updateItem).subscribe(
      response => { this.router.navigate(["/profile/", updateItem.gradId]) },
      error => { console.log(error)}
    );
  }

  deleteItem(deleteItemId: string, gradId: string): void {
    this.http.delete<Item>(this.apiItemUrl + deleteItemId).subscribe(
      response => { this.router.navigate(["/profile/", gradId]) },
      error => { console.log(error)}
    )
  }
}
