import { Injectable } from '@angular/core';
import { Item } from '../interfaces/item';

@Injectable({
  providedIn: 'root'
})

export class CartService {
  items: Item[] = [];
  count: number = 0;
  cartTotal: number = 0;

  constructor() {
  }

  addToCart(item: Item): void {
    this.items.push(item);
    this.count++;
  }

  getItems() {
    return this.items;
  }

  getItemCount(): number {
    return this.count;
  }
  
  emptyCart() {
    this.items = [];
    this.count = 0;
    this.cartTotal = 0;
    return this.items;
  }

  getCartTotal(): number {    
    this.items.forEach(item => {
      this.cartTotal += item.price;
    })

    return this.cartTotal;
  }

}
