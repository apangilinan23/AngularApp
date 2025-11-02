import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: false,
})
export class App implements OnInit {

  constructor() {}

  ngOnInit() {
    console.log('App initialized');
  }

  protected readonly title = signal('angularapp.client');
}
