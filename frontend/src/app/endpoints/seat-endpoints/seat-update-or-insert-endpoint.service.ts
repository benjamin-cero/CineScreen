import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface SeatUpdateOrInsertRequest {
  id?: number;
  cinemaHallId: number;
  seatNumber: string;
  seatType: string;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class SeatUpdateOrInsertEndpointService implements MyBaseEndpointAsync<SeatUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/seats`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: SeatUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 