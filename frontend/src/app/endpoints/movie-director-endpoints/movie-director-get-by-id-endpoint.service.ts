import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieDirectorGetByIdResponse {
  id: number;
  movieId: number;
  directorId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieDirectorGetByIdEndpointService implements MyBaseEndpointAsync<number, MovieDirectorGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/moviedirectors`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<MovieDirectorGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 