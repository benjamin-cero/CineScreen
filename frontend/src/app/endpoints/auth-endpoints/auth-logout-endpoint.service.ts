import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';
import {MyAuthService} from '../../services/auth-services/my-auth.service';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface LogoutResponse {
  isSuccess: boolean;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthLogoutEndpointService implements MyBaseEndpointAsync<void, LogoutResponse> {
  private apiUrl = `${MyConfig.api_address}/auth/logout`;

  constructor(private httpClient: HttpClient, private authService: MyAuthService) {
  }

  handleAsync(): Observable<LogoutResponse> {
    return new Observable<LogoutResponse>((observer) => {
      this.httpClient.post<LogoutResponse>(this.apiUrl, {}).subscribe({
        next: (response) => {
          console.log('Logout response:', response);
          
          // Always clear the token on the client side, regardless of server response
          this.authService.setLoggedInUser(null);
          
          if (response.isSuccess) {
            observer.next(response);
            observer.complete();
          } else {
            // Even if server logout failed, we still clear the client token
            observer.next(response);
            observer.complete();
          }
        },
        error: (error) => {
          console.error('Error during logout:', error);
          
          // Clear token even if there's an error
          this.authService.setLoggedInUser(null);
          
          // Return a default response for error cases
          const errorResponse: LogoutResponse = {
            isSuccess: false,
            message: 'Network error during logout. Token cleared locally.'
          };
          
          observer.next(errorResponse);
          observer.complete();
        }
      });
    });
  }
}
