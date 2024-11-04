import {Component, Input, input} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf, NgStyle} from '@angular/common';
import {argsArgArrayOrObject} from 'rxjs/internal/util/argsArgArrayOrObject';
import {colors} from '@angular/cli/src/utilities/color';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf, NgStyle],
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

  protected readonly argsArgArrayOrObject = argsArgArrayOrObject;
  protected readonly colors = colors;
}
