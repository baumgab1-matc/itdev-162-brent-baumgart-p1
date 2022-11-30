import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/interfaces/item';
import { CartService } from 'src/app/services/cart.service';
import { GradService } from 'src/app/services/grad.service';
import { Grad } from '../../interfaces/grad';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  id: string
  grad: Grad
  loadedGrad: Promise<boolean>

  constructor(
    private route: ActivatedRoute, 
    private gradService: GradService, 
    private carService: CartService) { 
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.gradService.getGradById(this.id).subscribe(grad => {
      this.grad = grad;
      // boolean flag to load html once we have data
      this.loadedGrad = Promise.resolve(true);
    });
  }

  addToCart(item: Item) {
    this.carService.addToCart(item);
    window.alert('You added an item');
  }

  deleteProfile() {
    const response = confirm("Are you sure you want to delete this profile?");
    
    if (response) {
      this.gradService.deleteGradProfile(this.id);
    }    
  }

}
