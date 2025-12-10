import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyConfig } from '../../my-config';

export interface MenuGetAllRequest {
  q?: string;
  minPrice?: number;
  maxPrice?: number;
  pageNumber: number;
  pageSize: number;
}

export interface ManufacturerResponse {
  id: number;
  name: string;
}

export interface MenuManufacturerResponse {
  id: number;
  tenantId: number;
  menuID: number;
  manufacturerID: number;
  manufacturer: ManufacturerResponse;
}

export interface MenuGetAllResponse {
  id: number;
  name: string;
  price: number;
  image: string | null;
  menuManufacturers: MenuManufacturerResponse[];
}

export interface MenuGetAllResponseWrapper {
  dataItems: MenuGetAllResponse[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
}

@Injectable({
  providedIn: 'root'
})
export class MenuGetAllEndpointService {
  private baseUrl = MyConfig.api_address;

  constructor(private http: HttpClient) {}

  handleAsync(request: MenuGetAllRequest, showLoader: boolean = false): Observable<MenuGetAllResponseWrapper> {
    let params = new HttpParams()
      .set('pageNumber', request.pageNumber.toString())
      .set('pageSize', request.pageSize.toString());

    if (request.q) {
      params = params.set('q', request.q);
    }

    if (request.minPrice !== undefined) {
      params = params.set('minPrice', request.minPrice.toString());
    }

    if (request.maxPrice !== undefined) {
      params = params.set('maxPrice', request.maxPrice.toString());
    }

    return this.http.get<MenuGetAllResponseWrapper>(`${this.baseUrl}/menus/filter`, { params });
  }
} 