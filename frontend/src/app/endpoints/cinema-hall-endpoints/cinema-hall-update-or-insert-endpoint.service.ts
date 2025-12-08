import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CinemaHallUpdateOrInsertRequest {
  id?: number;
  name: string;
  capacity: number;
}

@Injectable({
  providedIn: 'root'
})
export class CinemaHallUpdateOrInsertEndpointService implements MyBaseEndpointAsync<CinemaHallUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/cinema-halls`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: CinemaHallUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
}
