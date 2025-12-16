import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {CityGetAllResponse} from '../../../endpoints/city-endpoints/city-get-all-endpoint.service';
import {CityDeleteEndpointService} from '../../../endpoints/city-endpoints/city-delete-endpoint.service';
import {MyDialogConfirmComponent} from '../../shared/dialogs/my-dialog-confirm/my-dialog-confirm.component';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {
  CityGetAllEndpointService
} from '../../../endpoints/city-endpoints/city-get-all-endpoint.service';
import {debounceTime, distinctUntilChanged, Subject} from 'rxjs';

@Component({
  selector: 'app-cities3',
  templateUrl: './cities3.component.html',
  styleUrls: ['./cities3.component.css'],
  standalone: false
})
export class Cities3Component implements OnInit, AfterViewInit {
  //ovdje je koristeno Angular Reactive forms
  displayedColumns: string[] = ['name', 'actions'];
  dataSource: MatTableDataSource<CityGetAllResponse> = new MatTableDataSource<CityGetAllResponse>();
  cities: CityGetAllResponse[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private searchSubject: Subject<string> = new Subject();

  constructor(
    private cityGetService: CityGetAllEndpointService,
    private cityDeleteService: CityDeleteEndpointService,
    private router: Router,
    private dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.initSearchListener();
    this.fetchCities();
  }

  initSearchListener(): void {
    this.searchSubject.pipe(
      debounceTime(300), // Vrijeme čekanja (300ms)
      distinctUntilChanged(), // Emittuje samo ako je vrijednost promijenjena,
    ).subscribe((filterValue) => {
      this.fetchCities(filterValue, this.paginator.pageIndex + 1, this.paginator.pageSize);
    });
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      const filterValue = this.dataSource.filter || '';
      this.fetchCities(filterValue, this.paginator.pageIndex + 1, this.paginator.pageSize);
    });
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.searchSubject.next(filterValue); // Prosljeđuje vrijednost Subject-u
  }

  fetchCities(filter: string = '', page: number = 1, pageSize: number = 5): void {
    this.cityGetService.handleAsync(
      {
        q: filter,
        pageNumber: page,
        pageSize: pageSize
      },
      true,
    ).subscribe({
      next: (response) => {
        this.dataSource = new MatTableDataSource<CityGetAllResponse>(response.dataItems);
        this.paginator.length = response.totalCount; // Postavljanje ukupnog broja stavki
      },
      error: (err: any) => {
        console.error('Error fetching cities:', err);
      },
    });
  }

  editCity(id: number): void {
    this.router.navigate(['/admin/cities3/edit', id]);
  }

  deleteCity(id: number): void {

    this.cityDeleteService.handleAsync(id).subscribe({
      next: () => {
        console.log(`City with ID ${id} deleted successfully`);
        this.cities = this.cities.filter(city => city.id !== id); // Uklanjanje iz lokalne liste
      },
      error: (err: any) => console.error('Error deleting city:', err)
    });
  }

  openMyConfirmDialog(id: number) {
    const dialogRef = this.dialog.open(MyDialogConfirmComponent, {
      width: '350px',
      data: {
        title: 'Potvrda brisanja',
        message: 'Da li ste sigurni da želite obrisati ovu stavku?'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Korisnik je potvrdio brisanje');
        // Pozovite servis ili izvršite logiku za brisanje
        this.deleteCity(id);
      } else {
        console.log('Korisnik je otkazao brisanje');
      }
    });
  }
}
