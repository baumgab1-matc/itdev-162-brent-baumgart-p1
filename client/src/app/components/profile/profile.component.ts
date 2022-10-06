import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  id: string
  constructor(private route: ActivatedRoute) { 
    this.id = route.snapshot.params['id'];
  }

  ngOnInit(): void {
  }

}
