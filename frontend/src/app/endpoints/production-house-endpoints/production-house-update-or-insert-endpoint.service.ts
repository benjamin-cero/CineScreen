import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProductionHouseUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new production house insertion
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProductionHouseUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ProductionHouseUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/productionhouses`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: ProductionHouseUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 