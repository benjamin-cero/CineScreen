import {Component, OnInit, OnDestroy, HostListener} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {MyAuthService} from './services/auth-services/my-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: false
})
export class AppComponent implements OnInit {
  languages = [
    {code: 'bs', label: 'Bosanski'},
    {code: 'en', label: 'English'},
    {code: 'tr', label: 'Türkçe'}
  ];

  currentLanguage = 'bs';
  showLanguageMenu = false;
  showMobileMenu = false;
  isMobile = false;

  title = 'CineScreen';

  constructor(private translate: TranslateService, public authService: MyAuthService) {
    this.translate.setDefaultLang('bs');
    this.translate.use('bs');
  }

  ngOnInit(): void {
    this.checkScreenSize();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any): void {
    this.checkScreenSize();
  }

  checkScreenSize(): void {
    this.isMobile = window.innerWidth <= 768;
    if (!this.isMobile) {
      this.showMobileMenu = false;
    }
  }

  toggleMobileMenu(): void {
    this.showMobileMenu = !this.showMobileMenu;
  }

  closeMobileMenu(): void {
    this.showMobileMenu = false;
  }

  changeLanguage(lang: string): void {
    this.currentLanguage = lang;
    this.translate.use(lang);
    this.showLanguageMenu = false;
  }

  toggleLanguageMenu(): void {
    this.showLanguageMenu = !this.showLanguageMenu;
  }

  getCurrentLanguageLabel(): string {
    const lang = this.languages.find(l => l.code === this.currentLanguage);
    return lang ? lang.label : 'Bosanski';
  }

  getCurrentLanguageFlag(): string {
    return this.getFlagForLanguage(this.currentLanguage);
  }

  getFlagForLanguage(langCode: string): string {
    switch (langCode) {
      case 'bs':
        return '/images/bih.png';
      case 'en':
        return '/images/gb.png';
      case 'tr':
        return '/images/tur.png';
      default:
        return '/images/bih.png';
    }
  }
}
