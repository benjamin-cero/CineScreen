import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface GenreUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new genre insertion
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class GenreUpdateOrInsertEndpointService implements MyBaseEndpointAsync<GenreUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/genres`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: GenreUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 