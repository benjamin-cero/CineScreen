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

export interface MovieProductionHouseGetAllRequest extends MyPagedRequest {
  q?: string;
}

export interface MovieProductionHouseGetAllResponse {
  id: number;
  movieId: number;
  productionHouseId: number;
}

@Injectable({
  providedIn: 'root'
})
export class MovieProductionHouseGetAllEndpointService implements MyBaseEndpointAsync<MovieProductionHouseGetAllRequest, MyPagedList<MovieProductionHouseGetAllResponse>> {
  private apiUrl = `${MyConfig.api_address}/movie-production-houses/filter`;

  constructor(private httpClient: HttpClient, private cacheService: MyCacheService) {}

  handleAsync(request: MovieProductionHouseGetAllRequest, useCache: boolean = false, cacheTTL: number = 300000) {
    const cacheKey = `${request.q || ''}-${request.pageNumber || 1}-${request.pageSize || 10}`;
    if (useCache && this.cacheService.has(cacheKey)) {
      let data = this.cacheService.get<MyPagedList<MovieProductionHouseGetAllResponse>>(cacheKey)!;
      return of(data);
    }
    const params = buildHttpParams(request);
    return this.httpClient.get<MyPagedList<MovieProductionHouseGetAllResponse>>(`${this.apiUrl}`, {params}).pipe(
      tap((data) => {
        if (useCache) {
          this.cacheService.set(cacheKey, data, cacheTTL);
        }
      })
    );
  }
} 