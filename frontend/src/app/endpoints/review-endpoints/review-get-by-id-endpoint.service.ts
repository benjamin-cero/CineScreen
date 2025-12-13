import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ReviewGetByIdResponse {
  id: number;
  movieId: number;
  reviewDate: string;
  score: number;
  comment: string;
  myAppUserId: number;
  tenantId: number;
}

@Injectable({
  providedIn: 'root'
})
export class ReviewGetByIdEndpointService implements MyBaseEndpointAsync<number, ReviewGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/reviews`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.get<ReviewGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 