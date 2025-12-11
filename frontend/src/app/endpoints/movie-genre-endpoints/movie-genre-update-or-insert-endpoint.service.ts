import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieGenreUpdateOrInsertRequest {
  id?: number;
  movieId: number;
  genreId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieGenreUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MovieGenreUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/moviegenres`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MovieGenreUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 