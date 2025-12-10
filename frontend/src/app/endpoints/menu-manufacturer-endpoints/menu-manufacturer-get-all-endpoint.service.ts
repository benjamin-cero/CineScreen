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

export interface MenuManufacturerGetAllRequest extends MyPagedRequest {
  menuName?: string;
  manufacturerName?: string;
}

export interface MenuManufacturerGetAllResponse {
  id: number;
  menuId: number;
  menuName: string;
  manufacturerId: number;
  manufacturerName: string;
}

@Injectable({
  providedIn: 'root'
})
export class MenuManufacturerGetAllEndpointService implements MyBaseEndpointAsync<MenuManufacturerGetAllRequest, MyPagedList<MenuManufacturerGetAllResponse>> {
  private apiUrl = `${MyConfig.api_address}/menu-manufacturers/filter`;

  constructor(private httpClient: HttpClient, private cacheService: MyCacheService) {}

  handleAsync(request: MenuManufacturerGetAllRequest, useCache: boolean = false, cacheTTL: number = 300000) {
    const cacheKey = `${request.menuName || ''}-${request.manufacturerName || ''}-${request.pageNumber || 1}-${request.pageSize || 10}`;
    if (useCache && this.cacheService.has(cacheKey)) {
      let data = this.cacheService.get<MyPagedList<MenuManufacturerGetAllResponse>>(cacheKey)!;
      return of(data);
    }
    const params = buildHttpParams(request);
    return this.httpClient.get<MyPagedList<MenuManufacturerGetAllResponse>>(`${this.apiUrl}`, {params}).pipe(
      tap((data) => {
        if (useCache) {
          this.cacheService.set(cacheKey, data, cacheTTL);
        }
      })
    );
  }
} 