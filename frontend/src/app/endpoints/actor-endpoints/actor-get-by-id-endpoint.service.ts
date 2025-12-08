import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ActorGetByIdResponse {
  id:number;
  firstName: string;
  lastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class ActorGetByIdEndpointService implements MyBaseEndpointAsync<number, ActorGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/actors`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<ActorGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
