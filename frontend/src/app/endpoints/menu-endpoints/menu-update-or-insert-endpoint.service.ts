import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MenuUpdateOrInsertRequest {
  id?: number;
  name: string;
  price: number;
  image: string;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MenuUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MenuUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/menus`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MenuUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 