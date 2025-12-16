import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {ActorGetAllResponse} from '../../../endpoints/actor-endpoints/actor-get-all-endpoint.service';
import {ActorDeleteEndpointService} from '../../../endpoints/actor-endpoints/actor-delete-endpoint.service';
import {MyDialogConfirmComponent} from '../../shared/dialogs/my-dialog-confirm/my-dialog-confirm.component';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {ActorGetAllEndpointService} from '../../../endpoints/actor-endpoints/actor-get-all-endpoint.service';
import {debounceTime, distinctUntilChanged, Subject} from 'rxjs';

@Component({
  selector: 'app-actors',
  templateUrl: './actors.component.html',
  styleUrls: ['./actors.component.css'],
  standalone: false
})
export class ActorsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'actions'];
  dataSource: MatTableDataSource<ActorGetAllResponse> = new MatTableDataSource<ActorGetAllResponse>();
  actors: ActorGetAllResponse[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  private searchSubject: Subject<string> = new Subject();

  constructor(
    private actorGetService: ActorGetAllEndpointService,
    private actorDeleteService: ActorDeleteEndpointService,
    private router: Router,
    private dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.initSearchListener();
    this.fetchActors();
  }

  initSearchListener(): void {
    this.searchSubject.pipe(
      debounceTime(300), // Vrijeme čekanja (300ms)
      distinctUntilChanged(), // Emittuje samo ako je vrijednost promijenjena,
    ).subscribe((filterValue) => {
      this.fetchActors(filterValue, this.paginator.pageIndex + 1, this.paginator.pageSize);
    });
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      const filterValue = this.dataSource.filter || '';
      this.fetchActors(filterValue, this.paginator.pageIndex + 1, this.paginator.pageSize);
    });
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.searchSubject.next(filterValue); // Prosljeđuje vrijednost Subject-u
  }

  fetchActors(filter: string = '', page: number = 1, pageSize: number = 5): void {
    this.actorGetService.handleAsync(
      {
        q: filter,
        pageNumber: page,
        pageSize: pageSize
      },
      true,
    ).subscribe({
      next: (data) => {
        this.dataSource = new MatTableDataSource<ActorGetAllResponse>(data.dataItems);
        this.paginator.length = data.totalCount; // Postavljanje ukupnog broja stavki
      },
      error: (err) => {
        console.error('Error fetching actors:', err);
      },
    });
  }

  editActor(id: number): void {
    this.router.navigate(['/admin/actors/edit', id]);
  }

  deleteActor(id: number): void {
    this.actorDeleteService.handleAsync(id).subscribe({
      next: () => {
        console.log(`Actor with ID ${id} deleted successfully`);
        this.actors = this.actors.filter(actor => actor.id !== id); // Uklanjanje iz lokalne liste
        this.fetchActors(); // Refresh the data
      },
      error: (err) => console.error('Error deleting actor:', err)
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
        this.deleteActor(id);
      } else {
        console.log('Korisnik je otkazao brisanje');
      }
    });
  }
} 