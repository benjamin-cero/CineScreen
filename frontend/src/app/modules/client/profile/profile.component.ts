import { Component, OnInit } from '@angular/core';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';
import { AuthLogoutEndpointService } from '../../../endpoints/auth-endpoints/auth-logout-endpoint.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  standalone: false
})
export class ProfileComponent implements OnInit {
  userInfo: any = null;
  showProfileMenu = false;
  isLoggingOut = false;

  constructor(
    private authService: MyAuthService,
    private logoutService: AuthLogoutEndpointService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadUserInfo();
  }

  loadUserInfo(): void {
    this.userInfo = this.authService.getMyAuthInfo();
  }

  toggleProfileMenu(): void {
    this.showProfileMenu = !this.showProfileMenu;
  }

  onLogout(): void {
    if (this.isLoggingOut) return; // Prevent multiple logout attempts
    
    this.isLoggingOut = true;
    
    this.logoutService.handleAsync().subscribe({
      next: (response) => {
        console.log('Logout successful:', response.message);
        this.isLoggingOut = false;
        this.showProfileMenu = false;
        this.router.navigate(['/public/home']);
      },
      error: (error) => {
        console.error('Logout error:', error);
        this.isLoggingOut = false;
        // Even if there's an error, we still navigate to home since token is cleared
        this.showProfileMenu = false;
        this.router.navigate(['/public/home']);
      }
    });
  }

  onProfileClick(): void {
    this.router.navigate(['/client/profile']);
    this.showProfileMenu = false;
  }

  onSettingsClick(): void {
    this.router.navigate(['/client/settings']);
    this.showProfileMenu = false;
  }

  onReservationsClick(): void {
    this.router.navigate(['/client/reservations']);
    this.showProfileMenu = false;
  }
} 