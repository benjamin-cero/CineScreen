import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MenuGetByIdResponse {
  id: number;
  name: string;
  price: number;
  image: string;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MenuGetByIdEndpointService implements MyBaseEndpointAsync<number, MenuGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/menus`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<MenuGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 