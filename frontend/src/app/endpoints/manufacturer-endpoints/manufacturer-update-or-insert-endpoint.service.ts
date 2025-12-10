import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ManufacturerUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new manufacturer insertion
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ManufacturerUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ManufacturerUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/manufacturers`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: ManufacturerUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 