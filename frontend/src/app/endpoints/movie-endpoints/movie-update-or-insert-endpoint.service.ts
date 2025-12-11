import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new movie insertion
  title: string;
  releaseDate: string;
  description: string;
  duration: number;
  poster: string;
  trailer: string;
  status: string;
}

@Injectable({
  providedIn: 'root'
})
export class MovieUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MovieUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/movies`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: MovieUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 