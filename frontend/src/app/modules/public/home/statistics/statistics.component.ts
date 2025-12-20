import { Component, OnInit } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { NgForOf } from '@angular/common';
import {TranslatePipe} from '@ngx-translate/core';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  imports: [MatIcon, NgForOf, TranslatePipe],
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  statistics = [
    {
      icon: 'movie',
      number: '500+',
      label: 'HOME.STATISTICS.MOVIES_AVAILABLE',
      description: 'HOME.STATISTICS.MOVIES_DESCRIPTION'
    },
    {
      icon: 'people',
      number: '50K+',
      label: 'HOME.STATISTICS.HAPPY_CUSTOMERS',
      description: 'HOME.STATISTICS.CUSTOMERS_DESCRIPTION'
    },
    {
      icon: 'event_seat',
      number: '100K+',
      label: 'HOME.STATISTICS.TICKETS_SOLD',
      description: 'HOME.STATISTICS.TICKETS_DESCRIPTION'
    },
    {
      icon: 'theaters',
      number: '25+',
      label: 'HOME.STATISTICS.CINEMA_LOCATIONS',
      description: 'HOME.STATISTICS.LOCATIONS_DESCRIPTION'
    }
  ];

  constructor() {}

  ngOnInit(): void {
    this.animateNumbers();
  }

  animateNumbers(): void {
    // Add animation logic here if needed
    const observerOptions = {
      threshold: 0.5,
      rootMargin: '0px 0px -100px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('animate');
        }
      });
    }, observerOptions);

    // Observe all statistic items
    document.querySelectorAll('.statistic-item').forEach(item => {
      observer.observe(item);
    });
  }
}
