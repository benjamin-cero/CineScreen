import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface TicketGetByIdResponse {
  id: number;
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
export class TicketGetByIdEndpointService implements MyBaseEndpointAsync<number, TicketGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/tickets`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<TicketGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 