import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { MovieGetAllEndpointService, MovieGetAllResponse, MovieGetAllRequest } from '../../../endpoints/movie-endpoints/movie-get-all-endpoint.service';
import { GenreGetAllEndpointService, GenreGetAllResponse } from '../../../endpoints/genre-endpoints/genre-get-all-endpoint.service';
import { MovieGenreGetAllEndpointService, MovieGenreGetAllResponse } from '../../../endpoints/movie-genre-endpoints/movie-genre-get-all-endpoint.service';
import { ProjectionGetAllEndpointService, ProjectionGetAllResponse, ProjectionGetAllRequest } from '../../../endpoints/projection-endpoints/projection-get-all-endpoint.service';
import { MovieTypeGetAllEndpointService, MovieTypeGetAllResponse } from '../../../endpoints/movie-type-endpoints/movie-type-get-all-endpoint.service';
import { CinemaHallGetAllEndpointService, CinemaHallGetAllResponse } from '../../../endpoints/cinema-hall-endpoints/cinema-hall-get-all-endpoint.service';

interface MovieWithProjections extends MovieGetAllResponse {
  projections: ProjectionWithDetails[];
  earliestDate?: Date;
  genres: string[];
}

interface ProjectionWithDetails extends ProjectionGetAllResponse {
  movieType?: MovieTypeGetAllResponse;
  cinemaHall?: CinemaHallGetAllResponse;
}

interface ProjectionGroup {
  date: string;
  projections: ProjectionWithDetails[];
}

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    MatTabsModule,
    MatTooltipModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule
  ]
})
export class MoviesComponent implements OnInit {
  movies: MovieWithProjections[] = [];
  filteredMovies: MovieWithProjections[] = [];
  genres: GenreGetAllResponse[] = [];
  movieGenres: MovieGenreGetAllResponse[] = [];
  projections: ProjectionWithDetails[] = [];
  movieTypes: MovieTypeGetAllResponse[] = [];
  cinemaHalls: CinemaHallGetAllResponse[] = [];

  loading = true;
  filterForm: FormGroup;

  activeMovies: MovieWithProjections[] = [];
  upcomingMovies: MovieWithProjections[] = [];
  classicMovies: MovieWithProjections[] = [];

  private moviesShowingAllProjections = new Set<number>();
  selectedTabIndex = 0;

  constructor(
    private movieService: MovieGetAllEndpointService,
    private genreService: GenreGetAllEndpointService,
    private movieGenreService: MovieGenreGetAllEndpointService,
    private projectionService: ProjectionGetAllEndpointService,
    private movieTypeService: MovieTypeGetAllEndpointService,
    private cinemaHallService: CinemaHallGetAllEndpointService,
    private fb: FormBuilder,
    private translate: TranslateService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.filterForm = this.fb.group({
      search: [''],
      genre: ['']
    });
  }

  ngOnInit(): void {
    this.loadData();
    this.setupFiltering();

    this.route.queryParams.subscribe(params => {
      if (params['tab']) {
        this.selectedTabIndex = parseInt(params['tab'], 10) || 0;
      }
    });
  }

  loadData(): void {
    this.loading = true;

    Promise.all([
      this.loadGenres(),
      this.loadMovieGenres(),
      this.loadProjections(),
      this.loadMovieTypes(),
      this.loadCinemaHalls()
    ]).then(() => {
      this.loadMoviesWithFilters('', undefined);
    }).catch((error) => {
      console.error('Error loading data:', error);
      this.loading = false;
    });
  }

  loadMovies(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.movieService.handleAsync({ pageNumber: 1, pageSize: 100, q: '' }).subscribe({
        next: (response) => {
          this.movies = response.dataItems.map(movie => ({
            ...movie,
            projections: [],
            genres: []
          }));
          resolve();
        },
        error: reject
      });
    });
  }

  loadGenres(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.genreService.handleAsync({ pageNumber: 1, pageSize: 100, q: '' }).subscribe({
        next: (response) => {
          this.genres = response.dataItems;
          resolve();
        },
        error: reject
      });
    });
  }

  loadMovieGenres(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.movieGenreService.handleAsync({ pageNumber: 1, pageSize: 1000, q: '' }).subscribe({
        next: (response) => {
          this.movieGenres = response.dataItems;
          resolve();
        },
        error: reject
      });
    });
  }

  loadProjections(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.projectionService.handleAsync({ pageNumber: 1, pageSize: 1000, q: '' }).subscribe({
        next: (response) => {
          this.projections = response.dataItems;
          console.log('Loaded projections:', this.projections);
          console.log('First projection sample:', this.projections[0]);
          resolve();
        },
        error: reject
      });
    });
  }

  loadMovieTypes(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.movieTypeService.handleAsync({ pageNumber: 1, pageSize: 100, q: '' }).subscribe({
        next: (response) => {
          this.movieTypes = response.dataItems;
          resolve();
        },
        error: reject
      });
    });
  }

  loadCinemaHalls(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.cinemaHallService.handleAsync({ pageNumber: 1, pageSize: 100, q: '' }).subscribe({
        next: (response) => {
          this.cinemaHalls = response.dataItems;
          resolve();
        },
        error: reject
      });
    });
  }

  processMovies(): void {
    console.log('Processing movies...');
    console.log('Total movies:', this.movies.length);
    console.log('Total projections:', this.projections.length);
    console.log('Total movie types:', this.movieTypes.length);
    console.log('Total cinema halls:', this.cinemaHalls.length);
    console.log('Total movie genres:', this.movieGenres.length);

    if (this.projections.length > 0) {
      console.log('Sample projection data:', this.projections[0]);
    }

    if (this.movies.length > 0) {
      console.log('Sample movie data:', this.movies[0]);
    }

    this.movies.forEach(movie => {
      const movieProjections = this.projections.filter(p => p.movieID === movie.id);
      console.log(`Movie ${movie.title} (ID: ${movie.id}) has ${movieProjections.length} projections`);

      movieProjections.forEach(projection => {
        projection.movieType = this.movieTypes.find(mt => mt.id === projection.movieTypeID);
        projection.cinemaHall = this.cinemaHalls.find(ch => ch.id === projection.cinemaHallID);
        console.log(`Projection for ${movie.title}: ID=${projection.id}, ${projection.startTime}, Type: ${projection.movieType?.type}, Hall: ${projection.cinemaHall?.name}`);
      });

      movie.projections = movieProjections;

      if (movieProjections.length > 0) {
        const dates = movieProjections.map(p => new Date(p.startTime));
        movie.earliestDate = new Date(Math.min(...dates.map(d => d.getTime())));
      }

      movie.genres = this.getMovieGenres(movie.id);
      console.log(`Movie ${movie.title} genres:`, movie.genres);
    });

    this.filteredMovies = [...this.movies];

    this.categorizeMovies();

    console.log('Processing complete. Active movies:', this.activeMovies.length);
    console.log('Upcoming movies:', this.upcomingMovies.length);
    console.log('Classic movies:', this.classicMovies.length);
  }

  getMovieGenres(movieId: number): string[] {
    const movieGenreRelations = this.movieGenres.filter(mg => mg.movieID === movieId);
    console.log(`Movie ID ${movieId} genre relations:`, movieGenreRelations);
    console.log('Available genres:', this.genres);

    return movieGenreRelations.map(mg => {
      // Use genreName from the response if available, otherwise lookup in genres array
      if (mg.genreName) {
        console.log(`Using genreName from response: ${mg.genreName}`);
        return mg.genreName;
      }
      const genre = this.genres.find(g => g.id === mg.genreID);
      console.log(`Looking up genre ID ${mg.genreID}, found:`, genre);
      return genre ? genre.name : '';
    }).filter(name => name);
  }

  categorizeMovies(): void {
    this.activeMovies = this.filteredMovies.filter(m => m.status === 1);
    this.upcomingMovies = this.filteredMovies.filter(m => m.status === 2);
    this.classicMovies = this.filteredMovies.filter(m => m.status === 3);
  }

  setupFiltering(): void {
    this.filterForm.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged()
      )
      .subscribe(() => {
        this.applyFilters();
      });
  }

  applyFilters(): void {
    const searchTerm = this.filterForm.get('search')?.value || '';
    const selectedGenre = this.filterForm.get('genre')?.value || '';

    console.log('Applying filters - Search:', searchTerm, 'Genre:', selectedGenre);
    console.log('Available genres:', this.genres.map(g => g.name));

    // Find the genre ID for the selected genre name
    const selectedGenreId = selectedGenre ?
      this.genres.find(g => g.name === selectedGenre)?.id : undefined;

    // Load movies with backend filtering
    this.loadMoviesWithFilters(searchTerm, selectedGenreId);
  }

  loadMoviesWithFilters(searchTerm: string, genreId?: number): void {
    this.loading = true;

    this.movieService.handleAsync({
      pageNumber: 1,
      pageSize: 100,
      q: searchTerm,
      genreId: genreId
    }).subscribe({
      next: (response) => {
        this.movies = response.dataItems.map(movie => ({
          ...movie,
          projections: [],
          genres: []
        }));

        // Process movies to add genres and projections
        this.processMovies();
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading movies:', error);
        this.loading = false;
      }
    });
  }

  getMovieImage(poster: string | null): string {
    return poster ? `data:image/jpeg;base64,${poster}` : '/assets/default-movie.jpg';
  }

  onImageError(event: Event): void {
    const target = event.target as HTMLImageElement;
    if (target) {
      target.src = '/assets/default-movie.jpg';
    }
  }

  getProjectionGroups(movie: MovieWithProjections, limit?: number): ProjectionGroup[] {
    const groups: { [key: string]: ProjectionWithDetails[] } = {};

    console.log(`Getting projection groups for ${movie.title}, projections:`, movie.projections.length);

    movie.projections.forEach(projection => {
      const projectionDate = new Date(projection.startTime);
      const date = projectionDate.toDateString();
      console.log(`Projection date: ${projectionDate.toISOString()}, formatted: ${date}`);

      if (!groups[date]) {
        groups[date] = [];
      }
      groups[date].push(projection);
    });

    const result = Object.keys(groups).map(date => ({
      date,
      projections: groups[date].sort((a, b) =>
        new Date(a.startTime).getTime() - new Date(b.startTime).getTime()
      )
    })).sort((a, b) =>
      new Date(a.projections[0].startTime).getTime() - new Date(b.projections[0].startTime).getTime()
    );

    // Apply limit if specified
    if (limit && limit > 0) {
      return result.slice(0, limit);
    }

    console.log(`Projection groups for ${movie.title}:`, result);
    return result;
  }

  formatTime(dateTime: string): string {
    return new Date(dateTime).toLocaleTimeString('bs-BA', {
      hour: '2-digit',
      minute: '2-digit'
    });
  }

  formatDate(dateTime: string): string {
    const date = new Date(dateTime);
    const currentLang = this.translate.currentLang || 'bs';

    let locale = 'bs-BA';
    if (currentLang === 'en') locale = 'en-US';
    if (currentLang === 'tr') locale = 'tr-TR';

    const dayName = date.toLocaleDateString(locale, { weekday: 'long' });
    const dayMonth = date.toLocaleDateString('en-GB', {
      day: '2-digit',
      month: '2-digit'
    });
    return `${dayName}, ${dayMonth}`;
  }

  getStatusBadgeClass(status: number): string {
    switch (status) {
      case 1: return 'status-active';
      case 2: return 'status-upcoming';
      case 3: return 'status-classic';
      default: return 'status-default';
    }
  }

  getStatusText(status: number): string {
    switch (status) {
      case 1: return 'MOVIES.STATUS.ACTIVE'; // Active
      case 2: return 'MOVIES.STATUS.UPCOMING'; // Upcoming
      case 3: return 'MOVIES.STATUS.CLASSIC'; // Classic
      default: return 'MOVIES.STATUS.UNKNOWN';
    }
  }

  onProjectionTimeClick(projection: ProjectionWithDetails): void {
    // Immediate navigation without any delay
    console.log('Projection clicked, navigating immediately to:', projection.id);

    // Direct navigation - no setTimeout needed
    this.router.navigate(['/public/seat-selection', projection.id]);
  }

  toggleShowAllProjections(movie: MovieWithProjections): void {
    if (this.moviesShowingAllProjections.has(movie.id)) {
      this.moviesShowingAllProjections.delete(movie.id);
    } else {
      this.moviesShowingAllProjections.add(movie.id);
    }
  }

  isShowingAllProjections(movie: MovieWithProjections): boolean {
    return this.moviesShowingAllProjections.has(movie.id);
  }
}
