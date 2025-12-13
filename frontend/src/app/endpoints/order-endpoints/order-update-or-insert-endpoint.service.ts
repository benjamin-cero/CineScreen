import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface OrderUpdateOrInsertRequest {
  id?: number;
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
export class OrderUpdateOrInsertEndpointService implements MyBaseEndpointAsync<OrderUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/orders`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: OrderUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
}
