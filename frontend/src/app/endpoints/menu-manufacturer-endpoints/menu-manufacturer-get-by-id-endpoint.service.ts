import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MenuManufacturerGetByIdResponse {
  id: number;
  menuId: number;
  menuName: string;
  manufacturerId: number;
  manufacturerName: string;
}

@Injectable({
  providedIn: 'root'
})
export class MenuManufacturerGetByIdEndpointService implements MyBaseEndpointAsync<number, MenuManufacturerGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/menu-manufacturers`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: number) {
    return this.httpClient.get<MenuManufacturerGetByIdResponse>(`${this.apiUrl}/${request}`);
  }
} 