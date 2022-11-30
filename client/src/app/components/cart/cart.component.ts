import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/interfaces/item';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  items:Item[] = this.cartService.getItems();
  isButtonDisabled: boolean = this.cartService.getItemCount() > 0 ? false : true;
  cartTotal: number = 0;


  constructor(private cartService: CartService, private router: Router) { 
    this.cartTotal = cartService.getCartTotal();
  }

  ngOnInit(): void {

  }

  placeOrder(): void {
    window.alert("Order Placed");
    this.cartService.emptyCart();
    this.router.navigateByUrl('/');
  }

  cancelOrder(): void {
    this.cartService.emptyCart();
    this.router.navigateByUrl('/');
  }
}
