import { Component, OnInit } from '@angular/core';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css'],
  standalone: false
})
export class ProfilePageComponent implements OnInit {
  userInfo: any = null;
  isLoading = true;

  constructor(
    private authService: MyAuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadUserInfo();
  }

  loadUserInfo(): void {
    this.isLoading = true;
    this.userInfo = this.authService.getMyAuthInfo();
    
    if (!this.userInfo || !this.userInfo.isLoggedIn) {
      this.router.navigate(['/auth/login']);
      return;
    }
    
    this.isLoading = false;
  }

  onEditProfile(): void {
    // TODO: Implement edit profile functionality
    console.log('Edit profile clicked');
  }

  onBackToHome(): void {
    this.router.navigate(['/public/home']);
  }
} 