import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface TicketUpdateOrInsertRequest {
  id?: number;
  orderDate: string;
  projectionId: number;
  seatId: number;
  myAppUserId: number;
  paid: boolean;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class TicketUpdateOrInsertEndpointService implements MyBaseEndpointAsync<TicketUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/tickets`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: TicketUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 