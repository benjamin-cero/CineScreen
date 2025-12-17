import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {AuthLoginEndpointService} from '../../../endpoints/auth-endpoints/auth-login-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MyAuthService} from '../../../services/auth-services/my-auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false,
})
export class LoginComponent {
  form: FormGroup;
  showPassword = false;
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private authLoginService: AuthLoginEndpointService,
    private authService: MyAuthService,
    private router: Router
  ) {
    this.form = this.fb.group({
      email: ['benjamin.cero@edu.fit.ba', [Validators.required]],
      password: ['test', [Validators.required, Validators.minLength(3)]],
      rememberMe: [false]
    });
  }

  togglePassword(): void {
    this.showPassword = !this.showPassword;
  }

  onLogin(): void {
    if (this.form.invalid) return;

    this.isLoading = true;
    const loginData = {
      email: this.form.value.email,
      password: this.form.value.password
    };

    this.authLoginService.handleAsync(loginData).subscribe({
      next: (response) => {
        console.log('Login successful');
        this.isLoading = false;

        // Check user type and redirect accordingly
        if (this.authService.isAdmin()) {
          this.router.navigate(['/admin']);
        } else if (this.authService.isUser()) {
          this.router.navigate(['/client/profile']);
        } else {
          // Default redirect for other user types
          this.router.navigate(['/public/home']);
        }
      },
      error: (error) => {
        console.error('Login failed:', error);
        this.isLoading = false;
        // Handle login error (show message, etc.)
      }
    });
  }
}
