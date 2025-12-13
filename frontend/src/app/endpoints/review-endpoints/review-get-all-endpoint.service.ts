import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyPagedRequest} from '../../helper/my-paged-request';
import {MyConfig} from '../../my-config';
import {buildHttpParams} from '../../helper/http-params.helper';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {MyPagedList} from '../../helper/my-paged-list';
import {MyCacheService} from '../../services/cache-service/my-cache.service';
import {of} from 'rxjs';
import {tap} from 'rxjs/operators';

export interface ReviewGetAllRequest extends MyPagedRequest {
  q?: string;
}

export interface ReviewGetAllResponse {
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
export class ReviewGetAllEndpointService implements MyBaseEndpointAsync<ReviewGetAllRequest, MyPagedList<ReviewGetAllResponse>> {
  private apiUrl = `${MyConfig.api_address}/reviews/filter`;

  constructor(private httpClient: HttpClient, private cacheService: MyCacheService) {}

  handleAsync(request: ReviewGetAllRequest, useCache: boolean = false, cacheTTL: number = 300000) {
    const cacheKey = `${request.q || ''}-${request.pageNumber || 1}-${request.pageSize || 10}`;
    if (useCache && this.cacheService.has(cacheKey)) {
      let data = this.cacheService.get<MyPagedList<ReviewGetAllResponse>>(cacheKey)!;
      return of(data);
    }
    const params = buildHttpParams(request);
    return this.httpClient.get<MyPagedList<ReviewGetAllResponse>>(`${this.apiUrl}`, {params}).pipe(
      tap((data) => {
        if (useCache) {
          this.cacheService.set(cacheKey, data, cacheTTL);
        }
      })
    );
  }
} 