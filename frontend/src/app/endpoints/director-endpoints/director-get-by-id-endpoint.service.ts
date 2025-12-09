import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface DirectorGetByIdResponse {
  id: number;
  firstName: string;
  lastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class DirectorGetByIdEndpointService implements MyBaseEndpointAsync<number, DirectorGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/directors`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<DirectorGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
} 