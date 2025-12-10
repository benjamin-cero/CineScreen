import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MenuManufacturerUpdateOrInsertRequest {
  id?: number;
  menuId: number;
  manufacturerId: number;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MenuManufacturerUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MenuManufacturerUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/menumanufacturers`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MenuManufacturerUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 