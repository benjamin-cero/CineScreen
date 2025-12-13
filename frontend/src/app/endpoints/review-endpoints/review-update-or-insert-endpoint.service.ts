import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ReviewUpdateOrInsertRequest {
  id?: number;
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
export class ReviewUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ReviewUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/reviews`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: ReviewUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 