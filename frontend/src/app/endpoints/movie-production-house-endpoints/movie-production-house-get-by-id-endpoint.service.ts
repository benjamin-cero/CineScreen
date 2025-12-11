import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface MovieProductionHouseGetByIdResponse {
  id: number;
  movieId: number;
  productionHouseId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieProductionHouseGetByIdEndpointService implements MyBaseEndpointAsync<number, MovieProductionHouseGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/movieproductionhouses`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<MovieProductionHouseGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 