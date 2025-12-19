import { Component } from '@angular/core';
import {FeaturedMoviesComponent} from './featured-movies/featured-movies.component';
import {MovieCategoriesComponent} from './movie-categories/movie-categories.component';
import {MenuSectionComponent} from './menu-section/menu-section.component';
import {StatisticsComponent} from './statistics/statistics.component';
import {CtaSectionComponent} from './cta-section/cta-section.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  imports: [
    FeaturedMoviesComponent,
    MovieCategoriesComponent,
    MenuSectionComponent,
    StatisticsComponent,
    CtaSectionComponent
  ],
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
}
