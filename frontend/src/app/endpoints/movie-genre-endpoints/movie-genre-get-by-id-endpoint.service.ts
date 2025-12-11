import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieGenreGetByIdResponse {
  id: number;
  movieId: number;
  genreId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieGenreGetByIdEndpointService implements MyBaseEndpointAsync<number, MovieGenreGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/moviegenres`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<MovieGenreGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 