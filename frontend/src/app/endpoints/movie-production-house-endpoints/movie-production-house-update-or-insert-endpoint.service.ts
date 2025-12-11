import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieProductionHouseUpdateOrInsertRequest {
  id?: number;
  movieId: number;
  productionHouseId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieProductionHouseUpdateOrInsertEndpointService implements MyBaseEndpointAsync<MovieProductionHouseUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/movieproductionhouses`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: MovieProductionHouseUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 