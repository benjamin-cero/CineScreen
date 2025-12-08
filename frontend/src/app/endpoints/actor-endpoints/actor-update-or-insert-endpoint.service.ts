import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ActorUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new city insertion
  firstName: string;
  lastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class ActorUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ActorUpdateOrInsertRequest, void> {
  private apiUrl = `${MyConfig.api_address}/actors`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: ActorUpdateOrInsertRequest) {
    return this.httpClient.post<void>(`${this.apiUrl}`, request);
  }
}
