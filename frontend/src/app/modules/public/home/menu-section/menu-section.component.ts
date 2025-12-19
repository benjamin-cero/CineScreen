import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuGetAllResponse, MenuGetAllEndpointService } from '../../../../endpoints/menu-endpoints/menu-get-all-endpoint.service';
import { MatCard, MatCardContent } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatChip } from '@angular/material/chips';
import { NgForOf, NgIf } from '@angular/common';
import {TranslatePipe} from '@ngx-translate/core';

@Component({
  selector: 'app-menu-section',
  templateUrl: './menu-section.component.html',
  imports: [
    MatCard,
    MatCardContent,
    MatIcon,
    MatButton,
    MatChip,
    NgForOf,
    NgIf,
    TranslatePipe
  ],
  styleUrls: ['./menu-section.component.css']
})
export class MenuSectionComponent implements OnInit {
  popularMenuItems: MenuGetAllResponse[] = [];
  loading = true;

  constructor(
    private menuGetService: MenuGetAllEndpointService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.loadPopularMenuItems();
  }

  loadPopularMenuItems(): void {
    this.menuGetService.handleAsync(
      {
        q: '',
        pageNumber: 1,
        pageSize: 20
      },
      true,
    ).subscribe({
      next: (response) => {
        this.popularMenuItems = response.dataItems.filter(item =>
          item.id === 9 || item.id === 10 || item.id === 11
        );
        console.log('Popular menu items loaded:', this.popularMenuItems);
        this.popularMenuItems.forEach(item => {
          console.log(`Menu ${item.name} (ID: ${item.id}) manufacturers:`, item.menuManufacturers);
        });
        this.loading = false;
      },
      error: (err: any) => {
        console.error('Error fetching menu items:', err);
        this.loading = false;
      },
    });
  }

  getMenuImage(image: string | null): string {
    return image ? `data:image/jpeg;base64,${image}` : '/assets/default-menu.jpg';
  }

  getManufacturerNames(menuItem: MenuGetAllResponse): string[] {
    const manufacturers = (menuItem as any).MenuManufacturers || menuItem.menuManufacturers;
    if (!manufacturers || manufacturers.length === 0) {
      return [];
    }
    return manufacturers.map((mm: any) => {
      return mm.Manufacturer?.Name || mm.manufacturer?.name;
    }).filter((name: string) => name) as string[];
  }

  orderNow(menuItem: MenuGetAllResponse): void {
    this.router.navigate(['/client/menus'], { 
      queryParams: { scrollTo: menuItem.id } 
    });
  }

  viewFullMenu(): void {
    this.router.navigate(['/client/menus']).then(() => {
      window.scrollTo({ top: 0, behavior: 'smooth' });
    });
  }
}
