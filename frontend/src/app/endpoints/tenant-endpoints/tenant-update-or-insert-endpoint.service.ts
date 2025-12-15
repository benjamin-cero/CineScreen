import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface TenantUpdateOrInsertRequest {
  id?: number;
  name: string;
  databaseConnection: string;
  serverAddress: string;
}

@Injectable({
  providedIn: 'root'
})
export class TenantUpdateOrInsertEndpointService implements MyBaseEndpointAsync<TenantUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/tenants`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: TenantUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 