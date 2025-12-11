import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieGetByIdResponse {
  id: number;
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
export class MovieGetByIdEndpointService implements MyBaseEndpointAsync<number, MovieGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/movies`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<MovieGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 