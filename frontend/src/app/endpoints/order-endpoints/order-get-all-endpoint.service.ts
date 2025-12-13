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

export interface OrderGetAllRequest extends MyPagedRequest {
  q?: string;
  myAppUserId?: number;
  menuId?: number;
  paid?: boolean;
  fromDate?: string;
  toDate?: string;
}

export interface OrderGetAllResponse {
  id: number;
  orderDate: string;
  menuId: number;
  quantity: number;
  paid: boolean;
  myAppUserId: number;
  tenantId: number;
  menuName: string;
  totalPrice: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrderGetAllEndpointService implements MyBaseEndpointAsync<OrderGetAllRequest, MyPagedList<OrderGetAllResponse>> {
  private apiUrl = `${MyConfig.api_address}/orders/filter`;

  constructor(private httpClient: HttpClient, private cacheService: MyCacheService) {}

  handleAsync(request: OrderGetAllRequest, useCache: boolean = false, cacheTTL: number = 300000) {
    const cacheKey = `${request.q || ''}-${request.pageNumber || 1}-${request.pageSize || 10}`;
    if (useCache && this.cacheService.has(cacheKey)) {
      let data = this.cacheService.get<MyPagedList<OrderGetAllResponse>>(cacheKey)!;
      return of(data);
    }
    const params = buildHttpParams(request);
    return this.httpClient.get<MyPagedList<OrderGetAllResponse>>(`${this.apiUrl}`, {params}).pipe(
      tap((data) => {
        if (useCache) {
          this.cacheService.set(cacheKey, data, cacheTTL);
        }
      })
    );
  }
}
