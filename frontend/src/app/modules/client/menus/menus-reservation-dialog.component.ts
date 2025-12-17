import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { TranslateModule } from '@ngx-translate/core';
import { MenuGetAllResponse } from '../../../endpoints/menu-endpoints/menu-get-all-endpoint.service';

@Component({
  selector: 'app-client-menu-reservation-dialog',
  templateUrl: './menus-reservation-dialog.component.html',
  styleUrls: ['./menus-reservation-dialog.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    TranslateModule
  ]
})
export class MenusReservationDialogComponent {
  reservationForm: FormGroup;
  quantity = 1;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<MenusReservationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { menuItem: MenuGetAllResponse }
  ) {
    this.reservationForm = this.fb.group({
      quantity: [1, [Validators.required, Validators.min(1)]]
    });
  }

  increaseQuantity(): void {
    if (this.quantity < 10) {
      this.quantity++;
      this.reservationForm.patchValue({ quantity: this.quantity });
    }
  }

  decreaseQuantity(): void {
    if (this.quantity > 1) {
      this.quantity--;
      this.reservationForm.patchValue({ quantity: this.quantity });
    }
  }

  getTotalPrice(): number {
    return this.data.menuItem.price * this.quantity;
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onConfirm(): void {
    if (this.reservationForm.valid) {
      this.dialogRef.close({
        menuItem: this.data.menuItem,
        quantity: this.quantity,
        totalPrice: this.getTotalPrice()
      });
    }
  }
}
