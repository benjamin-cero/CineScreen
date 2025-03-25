import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  CityUpdateOrInsertEndpointService
} from '../../../../endpoints/city-endpoints/city-update-or-insert-endpoint.service';
import {CityGetByIdEndpointService} from '../../../../endpoints/city-endpoints/city-get-by-id-endpoint.service';

import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MyInputTextType} from '../../../shared/my-reactive-forms/my-input-text/my-input-text.component';

@Component({
  selector: 'app-cities3-edit',
  templateUrl: './cities3-edit.component.html',
  styleUrls: ['./cities3-edit.component.css'],
  standalone: false
})
export class Cities3EditComponent implements OnInit {
  cityForm: FormGroup;
  cityId: number;
  protected readonly MyInputTextType = MyInputTextType;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    public router: Router,
    private cityGetByIdService: CityGetByIdEndpointService,
    private cityUpdateService: CityUpdateOrInsertEndpointService,
  ) {
    this.cityId = 0;

    this.cityForm = this.fb.group({
      name: ['', [Validators.required, Validators.min(2), Validators.max(10)]],
    });

  }

  ngOnInit(): void {
    this.cityId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.cityId) {
      this.loadCityData();
    }

  }

  loadCityData(): void {
    this.cityGetByIdService.handleAsync(this.cityId).subscribe({
      next: (city) => {
        this.cityForm.patchValue({
          name: city.name,
        });
      },
      error: (error) => console.error('Error loading city data', error)
    });
  }



  updateCity(): void {
    if (this.cityForm.invalid) return;

    this.cityUpdateService.handleAsync({
      id: this.cityId,
      ...this.cityForm.value,
    }).subscribe({
      next: () => this.router.navigate(['/admin/cities3']),
      error: (error) => console.error('Error updating city', error)
    });
  }
}
