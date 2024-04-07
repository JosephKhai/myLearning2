import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.sass']
})
export class ChildComponent implements OnInit {

  myForm!: FormGroup;

  @Input() message: string = '';

  @Output() messageOut = new EventEmitter<string>();

  name: string = 'child message';

  constructor(private fb: FormBuilder) { }
  

  ngOnInit(): void {

    this.myForm = this.fb.group({
      name: ['', Validators.required],
      message: ['', Validators.required],

    });
  }

  sendToParent(form: FormGroup){
    this.messageOut.emit(form.value);

    console.log("Valid: " + form.valid);
    console.log("Name: " + form.value.name);
    console.log("Message: " + form.value.message);

  }

}
