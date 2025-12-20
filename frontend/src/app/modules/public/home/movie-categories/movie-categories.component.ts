import { Component, OnInit } from '@angular/core';
import { MovieGetAllResponse, MovieGetAllEndpointService } from '../../../../endpoints/movie-endpoints/movie-get-all-endpoint.service';
import { MatCard, MatCardHeader, MatCardTitle, MatCardContent, MatCardSubtitle } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { DatePipe, NgForOf, NgIf } from '@angular/common';
import {TranslatePipe} from '@ngx-translate/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-categories',
  templateUrl: './movie-categories.component.html',
  imports: [
    MatCard,
    MatCardHeader,
    MatCardTitle,
    MatCardContent,
    MatCardSubtitle,
    MatIcon,
    MatButton,
    DatePipe,
    NgForOf,
    NgIf,
    TranslatePipe
  ],
  styleUrls: ['./movie-categories.component.css']
})
export class MovieCategoriesComponent implements OnInit {
  categories = [
    {
      id: 1,
      titleKey: 'HOME.MOVIE_CATEGORIES.NOW_PLAYING.TITLE',
      descriptionKey: 'HOME.MOVIE_CATEGORIES.NOW_PLAYING.DESCRIPTION',
      icon: 'play_circle',
      cssClass: 'now-playing',
      movies: [] as MovieGetAllResponse[]
    },
    {
      id: 2,
      titleKey: 'HOME.MOVIE_CATEGORIES.COMING_SOON.TITLE',
      descriptionKey: 'HOME.MOVIE_CATEGORIES.COMING_SOON.DESCRIPTION',
      icon: 'schedule',
      cssClass: 'coming-soon',
      movies: [] as MovieGetAllResponse[]
    },
    {
      id: 3,
      titleKey: 'HOME.MOVIE_CATEGORIES.CLASSICS.TITLE',
      descriptionKey: 'HOME.MOVIE_CATEGORIES.CLASSICS.DESCRIPTION',
      icon: 'star',
      cssClass: 'classics',
      movies: [] as MovieGetAllResponse[]
    }
  ];

  constructor(
    private movieGetService: MovieGetAllEndpointService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadMoviesByCategory();
  }

  loadMoviesByCategory(): void {
    this.movieGetService.handleAsync(
      {
        q: '',
        pageNumber: 1,
        pageSize: 50
      },
      true,
    ).subscribe({
      next: (response) => {
        this.categories[0].movies = response.dataItems.filter(movie => movie.status === 1).slice(0, 3);
        this.categories[1].movies = response.dataItems.filter(movie => movie.status === 2).slice(0, 3);
        this.categories[2].movies = response.dataItems.filter(movie => movie.status === 3).slice(0, 3);
      },
      error: (err: any) => {
        console.error('Error fetching movies by category:', err);
      },
    });
  }

  getMoviePoster(poster: string): string {
    return poster ? `data:image/jpeg;base64,${poster}` : '/assets/default-poster.jpg';
  }

  viewAllMovies(categoryId: number): void {
    const tabIndex = categoryId - 1;
    this.router.navigate(['/public/movies'], { 
      queryParams: { tab: tabIndex } 
    });
  }
}
