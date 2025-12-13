import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProjectionUpdateOrInsertRequest {
  id?: number;
  cinemaHallId: number;
  movieId: number;
  movieTypeId: number;
  startTime: string;
  price: number;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectionUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ProjectionUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/projections`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: ProjectionUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 