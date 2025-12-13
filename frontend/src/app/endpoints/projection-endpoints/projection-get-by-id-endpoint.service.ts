import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProjectionGetByIdResponse {
  id: number;
  cinemaHallID: number;
  movieID: number;
  movieTypeID: number;
  startTime: string;
  price: number;
  movieTitle: string;
  cinemaHallName: string;
  movieTypeName: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectionGetByIdEndpointService implements MyBaseEndpointAsync<number, ProjectionGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/projections`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<ProjectionGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 