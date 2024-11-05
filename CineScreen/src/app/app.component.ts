import {Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf, NgStyle} from '@angular/common';
import {HttpClient, HttpClientModule} from '@angular/common/http';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf, NgStyle,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
 constructor(private HttpClient: HttpClient) {

 }

  name:string = "Benjamin"
   temp: string = "";
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

  ChangeColors() {
    return this.name.startsWith('A')?{backgroundColor:'Red'}:{backgroundColor:'Blue'};
  }

  fetchData() {
    const url = 'http://api.openweathermap.org/data/2.5/weather?q=Mostar&appid=917b026a997320574cd4315b9bf4c73a'
    /*fetch(`http://api.openweathermap.org/data/2.5/weather?q=Mostar&appid=917b026a997320574cd4315b9bf4c73a   `)
      .then(response => {
        response.json().then(pr => {
          ;
        })
      })*/
    this.HttpClient.get(url).subscribe((x:any) => {
      this.temp = (x.main.temp - 273).toFixed(1)
    });
  }
}
