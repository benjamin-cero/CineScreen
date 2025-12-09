import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface DirectorUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new director insertion
  firstName: string;
  lastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class DirectorUpdateOrInsertEndpointService implements MyBaseEndpointAsync<DirectorUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/directors`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: DirectorUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
} 