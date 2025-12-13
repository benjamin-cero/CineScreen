import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface SeatGetByIdResponse {
  id: number;
  cinemaHallId: number;
  seatNumber: string;
  seatType: string;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class SeatGetByIdEndpointService implements MyBaseEndpointAsync<number, SeatGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/seats`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<SeatGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 