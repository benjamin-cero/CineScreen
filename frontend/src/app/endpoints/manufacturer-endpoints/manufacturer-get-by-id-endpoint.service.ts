import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ManufacturerGetByIdResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ManufacturerGetByIdEndpointService implements MyBaseEndpointAsync<number, ManufacturerGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/manufacturers`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<ManufacturerGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 