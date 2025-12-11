import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieActorGetByIdResponse {
  id: number;
  movieId: number;
  actorId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieActorGetByIdEndpointService implements MyBaseEndpointAsync<number, MovieActorGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/movieactors`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<MovieActorGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 