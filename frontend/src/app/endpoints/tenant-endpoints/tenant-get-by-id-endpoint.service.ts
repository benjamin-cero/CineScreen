import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface TenantGetByIdResponse {
  id: number;
  name: string;
  databaseConnection: string;
  serverAddress: string;
}

@Injectable({
  providedIn: 'root'
})
export class TenantGetByIdEndpointService implements MyBaseEndpointAsync<number, TenantGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/tenants`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<TenantGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 