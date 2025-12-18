import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule, ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MenuGetAllEndpointService, MenuGetAllResponse, MenuGetAllResponseWrapper, MenuGetAllRequest } from '../../../endpoints/menu-endpoints/menu-get-all-endpoint.service';
import { MenuManufacturerGetAllEndpointService } from '../../../endpoints/menu-manufacturer-endpoints/menu-manufacturer-get-all-endpoint.service';
import { ManufacturerGetAllEndpointService } from '../../../endpoints/manufacturer-endpoints/manufacturer-get-all-endpoint.service';
import { OrderUpdateOrInsertEndpointService, OrderUpdateOrInsertRequest } from '../../../endpoints/order-endpoints/order-update-or-insert-endpoint.service';
import { MatDialog } from '@angular/material/dialog';
import { MenusReservationDialogComponent } from './menus-reservation-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-client-menus',
  templateUrl: './menus.component.html',
  standalone: false,
  styleUrls: ['./menus.component.css']
})
export class ClientMenusComponent implements OnInit {
  menuItems: MenuGetAllResponse[] = [];
  itemManufacturers: { [menuId: number]: string[] } = {};
  loading = true;
  filterForm: FormGroup;

  constructor(
    private menuService: MenuGetAllEndpointService,
    private orderService: OrderUpdateOrInsertEndpointService,
    private fb: FormBuilder,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private manufacturerGetAllEndpointService:MenuManufacturerGetAllEndpointService,
    private authService: MyAuthService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.filterForm = this.fb.group({
      search: [''],
    });
  }

  ngOnInit(): void {
    this.fetchMenu();
    
    this.route.queryParams.subscribe(params => {
      if (params['scrollTo']) {
        const menuId = parseInt(params['scrollTo']);
        setTimeout(() => {
          this.scrollToMenuItem(menuId);
        }, 1000);
      }
    });
  }

  fetchMenu(filters?: { search?: string; minPrice?: number; maxPrice?: number }): void {
    this.loading = true;
    const request: MenuGetAllRequest = {
      pageNumber: 1,
      pageSize: 20,
      q: filters?.search || undefined,
    };

    this.menuService.handleAsync(request, false).subscribe({
      next: (res: MenuGetAllResponseWrapper) => {
        console.log('Raw menu response from backend:', res);
        this.menuItems = res.dataItems;
        console.log('Menu items loaded:', this.menuItems);
        this.processManufacturers();
        this.loading = false;
      },
      error: () => { this.loading = false; }
    });
  }

  processManufacturers(): void {
    const map: { [menuId: number]: string[] } = {};
    console.log('Processing manufacturers for', this.menuItems.length, 'menu items');
    
    this.menuItems.forEach(item => {
      console.log(`Menu item ${item.name} (ID: ${item.id}) has manufacturers:`, item.menuManufacturers);
      
      const manufacturers = (item as any).MenuManufacturers || item.menuManufacturers;
      if (manufacturers && manufacturers.length > 0) {
        map[item.id] = manufacturers
          .map((mm: any) => {
            const manufacturerName = mm.Manufacturer?.Name || mm.manufacturer?.name;
            console.log(`  Manufacturer mapping: ID ${mm.ManufacturerID || mm.manufacturerID} -> ${manufacturerName}`);
            return manufacturerName;
          })
          .filter((name: string) => name) as string[];
        console.log(`Final manufacturers for ${item.name}:`, map[item.id]);
      } else {
        console.log(`No manufacturers found for ${item.name}`);
      }
    });
    
    this.itemManufacturers = map;
    console.log('Final manufacturer map:', this.itemManufacturers);
  }

  getMenuImage(image: string | null): string { return image ? `data:image/jpeg;base64,${image}` : '/assets/default-menu.jpg'; }
  onImageError(e: Event){ const t = e.target as HTMLImageElement; if(t) t.src='/assets/default-menu.jpg'; }
  applyFilters(): void {
    const searchValue = this.filterForm.get('search')?.value;
    this.fetchMenu({ search: searchValue });
  }

  clearFilters(): void {
    this.filterForm.reset();
    this.fetchMenu();
  }

  isUserLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  navigateToLogin(): void {
    this.router.navigate(['/auth/login']);
  }

  openReservation(item: MenuGetAllResponse): void {
    if (!this.isUserLoggedIn()) {
      this.snackBar.open('Molimo prijavite se da biste mogli rezervisati proizvode', 'Prijavite se', {
        duration: 4000,
        panelClass: ['error-snackbar']
      }).onAction().subscribe(() => {
        this.router.navigate(['/auth/login']);
      });
      return;
    }
    const ref = this.dialog.open(MenusReservationDialogComponent, { width: '500px', maxWidth: '95vw', data: { menuItem: item } });
    ref.afterClosed().subscribe((result?: { quantity: number }) => {
      if (!result) return;
      
      const authInfo = this.authService.getMyAuthInfo();
      if (!authInfo) {
        this.snackBar.open('Greška: Korisnik nije prijavljen', 'OK', { duration: 3000 });
        return;
      }

      const request: OrderUpdateOrInsertRequest = {
        orderDate: new Date().toISOString(),
        menuId: item.id,
        quantity: result.quantity,
        paid: false,
        myAppUserId: authInfo.userId,
        tenantId: 0
      };

      this.orderService.handleAsync(request).subscribe({
        next: () => {
          this.snackBar.open(
            `✅ Narudžba uspješno rezervisana! ${result.quantity}x ${item.name}`, 
            'OK', 
            { 
              duration: 5000,
              panelClass: ['success-snackbar']
            }
          );
        },
        error: (error) => {
          console.error('Order creation error:', error);
          this.snackBar.open(
            '❌ Greška pri rezervaciji. Molimo pokušajte ponovo.', 
            'OK', 
            { 
              duration: 4000,
              panelClass: ['error-snackbar']
            }
          );
        }
      });
    });
  }

  scrollToMenuItem(menuId: number): void {
    const element = document.getElementById(`menu-item-${menuId}`);
    if (element) {
      element.scrollIntoView({ 
        behavior: 'smooth', 
        block: 'center' 
      });
      
      element.classList.add('highlight-item');
      
      setTimeout(() => {
        element.classList.remove('highlight-item');
      }, 3000);
    }
  }
}


