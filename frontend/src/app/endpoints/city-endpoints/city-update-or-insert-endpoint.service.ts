import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CityUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new city insertion
  name: string;
}

export interface CityUpdateOrInsertResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityUpdateOrInsertEndpointService implements MyBaseEndpointAsync<CityUpdateOrInsertRequest, CityUpdateOrInsertResponse> {
  private apiUrl = `${MyConfig.api_address}/cities`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: CityUpdateOrInsertRequest) {
    return this.httpClient.post<CityUpdateOrInsertResponse>(`${this.apiUrl}`, request);
  }
}
