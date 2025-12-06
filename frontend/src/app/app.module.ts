import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClient, HttpClientModule} from '@angular/common/http';
import {MyAuthInterceptor} from './services/auth-services/my-auth-interceptor.service';
import {MyAuthService} from './services/auth-services/my-auth.service';
import {SharedModule} from './modules/shared/shared.module';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MyErrorHandlingInterceptor} from './services/auth-services/my-error-handling-interceptor.service';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {MatIcon} from '@angular/material/icon';
import {CustomTranslateLoader} from './services/custom-translate-loader';
import {ProfileComponent} from './modules/client/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (http: HttpClient) => new CustomTranslateLoader(http),
        deps: [HttpClient]
      }
    }),
    MatFormField,
    MatSelect,
    MatOption,
    MatLabel,
    MatIcon
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MyAuthInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MyErrorHandlingInterceptor,
      multi: true
    },
    MyAuthService,
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
