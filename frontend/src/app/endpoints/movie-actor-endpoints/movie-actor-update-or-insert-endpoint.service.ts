import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieActorUpdateOrInsertRequest {
  id?: number;
  movieId: number;
  actorId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieActorUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MovieActorUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/movieactors`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MovieActorUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 