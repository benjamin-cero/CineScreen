import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface GenreGetByIdResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class GenreGetByIdEndpointService implements MyBaseEndpointAsync<number, GenreGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/genres`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<GenreGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 