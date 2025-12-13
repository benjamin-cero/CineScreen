import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface OrderGetByIdResponse {
  id: number;
  orderDate: string;
  menuId: number;
  quantity: number;
  paid: boolean;
  myAppUserId: number;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrderGetByIdEndpointService implements MyBaseEndpointAsync<number, OrderGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/orders`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<OrderGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 