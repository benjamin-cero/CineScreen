import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MovieGetAllResponse, MovieGetAllEndpointService } from '../../../../endpoints/movie-endpoints/movie-get-all-endpoint.service';
import { debounceTime, distinctUntilChanged, Subject } from 'rxjs';
import { MatCard, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { DatePipe, NgForOf, NgIf } from '@angular/common';
import { MatIconButton } from '@angular/material/button';
import {TranslatePipe} from '@ngx-translate/core';
import { interval, Subscription } from 'rxjs';


@Component({

  selector: 'app-featured-movies',
  templateUrl: './featured-movies.component.html',

  imports: [
    MatCardTitle,
    MatCardHeader,
    MatCard,
    MatIcon,
    DatePipe,
    NgIf,
    MatIconButton,
    NgForOf,
    TranslatePipe
  ],
  styleUrls: ['./featured-movies.component.css']
})
export class FeaturedMoviesComponent implements OnInit {
  movies: MovieGetAllResponse[] = [];
  currentIndex = 0;
  private searchSubject: Subject<string> = new Subject();
  autoSlideSubscription: Subscription | undefined;

  constructor(
    private movieGetService: MovieGetAllEndpointService
  ) {}

  ngOnInit(): void {
    this.fetchFeaturedMovies();
    this.startAutoSlide();
  }
  startAutoSlide(): void {
    this.autoSlideSubscription = interval(6000).subscribe(() => {
      this.nextMovie();
    });
  }

  ngOnDestroy(): void {
    this.autoSlideSubscription?.unsubscribe();
  }

  fetchFeaturedMovies(): void {
    this.movieGetService.handleAsync(
      {
        q: '',
        pageNumber: 1,
        pageSize: 50
      },
      true,
    ).subscribe({
      next: (response) => {
        this.movies = response.dataItems.filter(movie => movie.status === 1);
        this.currentIndex = 0;
      },
      error: (err: any) => {
        console.error('Error fetching featured movies:', err);
      },
    });
  }

  nextMovie(): void {
    if (this.movies.length > 0) {
      this.currentIndex = (this.currentIndex + 1) % this.movies.length;
    }
  }

  previousMovie(): void {
    if (this.movies.length > 0) {
      this.currentIndex = this.currentIndex === 0 ? this.movies.length - 1 : this.currentIndex - 1;
    }
  }

  selectMovie(movie: MovieGetAllResponse): void {
    console.log('Selected featured movie:', movie);
  }

  getCurrentMovie(): MovieGetAllResponse | null {
    return this.movies.length > 0 ? this.movies[this.currentIndex] : null;
  }

  getMovieStatus(status: number): string {
    console.log('getMovieStatus called with status:', status, 'type:', typeof status);
    switch (status) {
      case 1:
        return 'Now Playing';
      case 2:
        return 'Coming Soon';
      case 3:
        return 'Classic';
      case 4:
        return 'Hidden';
      default:
        return 'Unknown';
    }
  }

  getStatusColor(status: number): string {
    console.log('getStatusColor called with status:', status, 'type:', typeof status);
    switch (status) {
      case 1:
        return 'accent';
      case 2:
        return 'warn';
      case 3:
        return 'primary';
      case 4:
        return '';
      default:
        return '';
    }
  }

  getMoviePoster(poster: string): string {
    return poster ? `data:image/jpeg;base64,${poster}` : '/assets/default-poster.jpg';
  }
}
