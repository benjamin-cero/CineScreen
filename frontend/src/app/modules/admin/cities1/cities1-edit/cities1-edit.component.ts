import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  CityUpdateOrInsertEndpointService
} from '../../../../endpoints/city-endpoints/city-update-or-insert-endpoint.service';
import {
  CityGetByIdEndpointService,
  CityGetByIdResponse
} from '../../../../endpoints/city-endpoints/city-get-by-id-endpoint.service';
import {MySnackbarHelperService} from '../../../shared/snackbars/my-snackbar-helper.service';

@Component({
  selector: 'app-cities1-edit',
  templateUrl: './cities1-edit.component.html',
  styleUrls: ['./cities1-edit.component.css'],
  standalone: false
})
export class Cities1EditComponent implements OnInit {
  cityId: number;
  city: CityGetByIdResponse = {
    id: 0,
    name: '',
  };


  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private cityGetByIdService: CityGetByIdEndpointService,
    private cityUpdateService: CityUpdateOrInsertEndpointService,
    private snackbarHelper: MySnackbarHelperService
  ) {
    this.cityId = 0;
  }

  ngOnInit(): void {
    this.cityId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.cityId) {
      this.loadCityData();
    }
  }

  loadCityData(): void {
    this.cityGetByIdService.handleAsync(this.cityId).subscribe({
      next: (city) => this.city = city,
      error: (error) => console.error('Error loading city data', error)
    });
  }


  updateCity(): void {

    let errors: string[] = [];


    if (this.city.name.length == 0) {
      errors.push("name is required");
    }

    if (errors.length > 0) {
      alert("errros: " + errors.join("\n"));
      return;
    }

    this.cityUpdateService.handleAsync({
      id: this.cityId,
      name: this.city.name
    }).subscribe({
      next: () => {
        this.snackbarHelper.showMessage('Uspješno snimljene izmjene');
        this.router.navigate(['/admin/cities1']);
      },
      error: (error) => console.error('Error updating city', error)
    });
  }
}
