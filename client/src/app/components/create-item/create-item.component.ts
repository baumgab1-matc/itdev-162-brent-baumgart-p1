import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/interfaces/item';
import { Grad } from '../../interfaces/grad';
import { NgForm } from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-create-item',
  templateUrl: './create-item.component.html',
  styleUrls: ['./create-item.component.css']
})
export class CreateItemComponent implements OnInit {

  gradId: string 
  grad: Grad

  item:Item= {
    gradId: '',
    name: '',
    description: '',
    category: 'Text Books',
    price: 0
  }

  @ViewChild('f') itemForm: NgForm;

  constructor(
    private router: Router,
    private route: ActivatedRoute, 
    private itemService: ItemService,
    ) {}

    ngOnInit(): void {
    this.gradId = this.route.snapshot.params['gradId'];
  }

  onSubmit(item:Item): void {
    this.itemService.addItem(item);    
  }

  cancelAdd(): void {
    this.router.navigate(["/profile/", this.gradId]);
  }

}
