import { Component, OnInit } from '@angular/core';
import { GradService } from 'src/app/services/grad.service';
import { Grad } from '../../interfaces/grad';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'client';
  grads: Grad[] = [];

  constructor(private gradService: GradService) {}

  ngOnInit(): void {
    this.gradService.getGrads().subscribe((grads) => (this.grads = grads));
  }

}
