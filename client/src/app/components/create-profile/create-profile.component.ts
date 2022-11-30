import { Component, OnInit, ViewChild } from '@angular/core';
import { Grad } from '../../interfaces/grad';
import { NgForm } from '@angular/forms';
import { GradService } from 'src/app/services/grad.service';

@Component({
  selector: 'app-create-profile',
  templateUrl: './create-profile.component.html',
  styleUrls: ['./create-profile.component.css']
})
export class CreateProfileComponent implements OnInit {

  @ViewChild('f') itemForm: NgForm;

  grad:Grad={
    userName: ''
  }

  constructor(private gradService: GradService) { }

  ngOnInit(): void {
  }

  onSubmit(grad: Grad): void {
     this.gradService.addNewGradProfile(grad);
  }

}
