import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieDirectorUpdateOrInsertRequest {
  id?: number;
  movieId: number;
  directorId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieDirectorUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MovieDirectorUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/moviedirectors`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MovieDirectorUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 