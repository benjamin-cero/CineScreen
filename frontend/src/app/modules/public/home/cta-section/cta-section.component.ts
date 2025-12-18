import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import {TranslatePipe} from '@ngx-translate/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cta-section',
  templateUrl: './cta-section.component.html',
  imports: [MatButton, MatIcon, TranslatePipe],
  styleUrls: ['./cta-section.component.css']
})
export class CtaSectionComponent {

  constructor(private router: Router) {}

  registerNow(): void {
    this.router.navigate(['/auth/login']);
  }

  learnMore(): void {
    this.router.navigate(['/public/contact-us']).then(() => {
      window.scrollTo({ top: 0, behavior: 'smooth' });
    });
  }
}
