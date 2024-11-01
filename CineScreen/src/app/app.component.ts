import {Component, Input, input} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf} from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name:string = "Benjamin"
  getname():string{
    return "HELLO " + " " + this.name;
  }
  brojac:number=0;
  button1click():void{
    this.name += ("." + this.brojac++);
  }
niz:string[] = ["jedan", "dva", "tri", "cetri"];
  showHeader() {
    return this.name.length>2;
  }
}
