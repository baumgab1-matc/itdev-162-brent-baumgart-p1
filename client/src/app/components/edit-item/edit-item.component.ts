import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'src/app/interfaces/item';
import { GradService } from 'src/app/services/grad.service';
import { Grad } from '../../interfaces/grad';
import { NgForm } from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';


@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.css']
})
export class EditItemComponent implements OnInit {
  gradId: string
  itemId: string
  grad: Grad
  loadedGrad: Promise<boolean>

  item:Item= {
    gradId: '',
    name: '',
    description: '',
    category: '',
    price: 0
  }

  @ViewChild('f') itemForm: NgForm;

  constructor(
    private router: Router,
    private route: ActivatedRoute, 
    private gradService: GradService,
    private itemService: ItemService
    ) {}

  ngOnInit(): void {
    this.gradId = this.route.snapshot.params['gradId'];
    this.itemId = this.route.snapshot.params['itemId'];

    this.itemService.getItemById(this.itemId).subscribe(item => {
      this.item = item;
      this.loadedGrad = Promise.resolve(true);
    });
  }

  onSubmit(updateItem: Item): void {
     this.itemService.updateItem(updateItem);
  }

  cancelUpdate(): void {    
    this.router.navigate(["/profile/", this.gradId]);
  }

  deleteItem(): void {
    this.itemService.deleteItem(this.itemId, this.gradId);
  }

}
