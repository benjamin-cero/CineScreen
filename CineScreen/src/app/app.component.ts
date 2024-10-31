import {Component, Input, input} from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name:string = "Benjamin"
  getname():string{
    let r = Math.random();
    return "HELLO " + this.name + " " + r;
  }
  brojac:number=0;
  button1click():void{
    this.name += ("." + this.brojac++);
  }
  nameChangeEvent($event: Event) {
    // @ts-ignore
    let v= $event.target.value;

  }
}
