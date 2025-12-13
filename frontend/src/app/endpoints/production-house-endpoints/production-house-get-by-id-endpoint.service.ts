import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProductionHouseGetByIdResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProductionHouseGetByIdEndpointService implements MyBaseEndpointAsync<number, ProductionHouseGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/productionhouses`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<ProductionHouseGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 