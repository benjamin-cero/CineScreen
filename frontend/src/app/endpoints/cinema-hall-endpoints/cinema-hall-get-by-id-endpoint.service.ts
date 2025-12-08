import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CinemaHallGetByIdResponse {
  id: number;
  name: string;
  capacity: number;
}

@Injectable({
  providedIn: 'root'
})
export class CinemaHallGetByIdEndpointService implements MyBaseEndpointAsync<number, CinemaHallGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/cinema-halls`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<CinemaHallGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
