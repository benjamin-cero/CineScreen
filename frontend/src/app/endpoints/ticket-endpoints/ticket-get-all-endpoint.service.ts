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

export interface TicketGetAllRequest extends MyPagedRequest {
  q?: string;
}

export interface TicketGetAllResponse {
  id: number;
  orderDate: string;
  projectionID: number;
  seatID: number;
  myAppUserID: number;
  paid: boolean;
  userName: string;
  seatNumber: string;
  cinemaHallName: string;
  movieTitle: string;
  projectionStartTime: string;
  ticketPrice: number;
}

@Injectable({
  providedIn: 'root'
})
export class TicketGetAllEndpointService implements MyBaseEndpointAsync<TicketGetAllRequest, MyPagedList<TicketGetAllResponse>> {
  private apiUrl = `${MyConfig.api_address}/tickets/filter`;

  constructor(private httpClient: HttpClient, private cacheService: MyCacheService) {}

  handleAsync(request: TicketGetAllRequest, useCache: boolean = false, cacheTTL: number = 300000) {
    const cacheKey = `${request.q || ''}-${request.pageNumber || 1}-${request.pageSize || 10}`;
    if (useCache && this.cacheService.has(cacheKey)) {
      let data = this.cacheService.get<MyPagedList<TicketGetAllResponse>>(cacheKey)!;
      return of(data);
    }
    const params = buildHttpParams(request);
    return this.httpClient.get<MyPagedList<TicketGetAllResponse>>(`${this.apiUrl}`, {params}).pipe(
      tap((data) => {
        if (useCache) {
          this.cacheService.set(cacheKey, data, cacheTTL);
        }
      })
    );
  }
} 