import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.sass']
})
export class ParentComponent implements OnInit {

  message: string = "Hello This is a message from ParentComponent";

  childMessage: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  receiveMessage(message: string): void {
    this.childMessage = message;
   }

}
