import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

import { ProjectionGetByIdEndpointService, ProjectionGetByIdResponse } from '../../../endpoints/projection-endpoints/projection-get-by-id-endpoint.service';
import { SeatGetAllEndpointService, SeatGetAllResponse } from '../../../endpoints/seat-endpoints/seat-get-all-endpoint.service';
import { TicketGetAllEndpointService, TicketGetAllResponse } from '../../../endpoints/ticket-endpoints/ticket-get-all-endpoint.service';
import { MovieGetByIdEndpointService, MovieGetByIdResponse } from '../../../endpoints/movie-endpoints/movie-get-by-id-endpoint.service';
import { CinemaHallGetByIdEndpointService, CinemaHallGetByIdResponse } from '../../../endpoints/cinema-hall-endpoints/cinema-hall-get-by-id-endpoint.service';
import { MovieTypeGetAllEndpointService, MovieTypeGetAllResponse } from '../../../endpoints/movie-type-endpoints/movie-type-get-all-endpoint.service';
import { TicketUpdateOrInsertEndpointService, TicketUpdateOrInsertRequest } from '../../../endpoints/ticket-endpoints/ticket-update-or-insert-endpoint.service';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';

export interface SeatWithStatus extends SeatGetAllResponse {
  isOccupied: boolean;
  isSelected: boolean;
  priceMultiplier: number;
}

export interface SeatRow {
  rowLetter: string;
  seats: SeatWithStatus[];
}

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    RouterModule
  ]
})
export class SeatSelectionComponent implements OnInit {
  projection?: ProjectionGetByIdResponse;
  movie?: MovieGetByIdResponse;
  cinemaHall?: CinemaHallGetByIdResponse;
  movieType?: MovieTypeGetAllResponse;

  allSeats: SeatGetAllResponse[] = [];
  occupiedTickets: TicketGetAllResponse[] = [];
  seatRows: SeatRow[] = [];

  selectedSeats: SeatWithStatus[] = [];
  ticketQuantity = 1;
  totalPrice = 0;
  basePrice = 0;

  loading = true;
  isLoggedIn = false;

  seatPriceMultipliers: { [key: string]: number } = {
    'Regular': 1.0,
    'Love': 1.5,
    'Wheelchair': 1.0,
    '1': 1.0,
    '2': 1.5,
    '3': 1.0
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private projectionService: ProjectionGetByIdEndpointService,
    private seatService: SeatGetAllEndpointService,
    private ticketService: TicketGetAllEndpointService,
    private movieService: MovieGetByIdEndpointService,
    private cinemaHallService: CinemaHallGetByIdEndpointService,
    private movieTypeService: MovieTypeGetAllEndpointService,
    private ticketCreateService: TicketUpdateOrInsertEndpointService,
    private translate: TranslateService,
    private snackBar: MatSnackBar,
    private authService: MyAuthService
  ) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();

    const projectionId = Number(this.route.snapshot.paramMap.get('projectionId'));
    if (projectionId) {
      this.loadProjectionData(projectionId);
    } else {
      this.router.navigate(['/public/movies']);
    }
  }

  async loadProjectionData(projectionId: number): Promise<void> {
    try {
      this.loading = true;

      const projection = await this.projectionService.handleAsync(projectionId).toPromise();
      if (!projection) {
        throw new Error('Projection not found');
      }
      this.projection = projection;
      this.basePrice = projection.price;

      const [movie, cinemaHall, movieTypes, seats, tickets] = await Promise.all([
        this.movieService.handleAsync(projection.movieID).toPromise(),
        this.cinemaHallService.handleAsync(projection.cinemaHallID).toPromise(),
        this.movieTypeService.handleAsync({ pageNumber: 1, pageSize: 100, q: '' }).toPromise(),
        this.seatService.handleAsync({ pageNumber: 1, pageSize: 1000, q: '' }).toPromise(),
        this.ticketService.handleAsync({ pageNumber: 1, pageSize: 1000, q: '' }).toPromise()
      ]);

      this.movie = movie!;
      this.cinemaHall = cinemaHall!;
      this.movieType = movieTypes!.dataItems.find(mt => mt.id === projection.movieTypeID);

      console.log('Projection data:', projection);
      console.log('All seats loaded:', seats!.dataItems.length);
      console.log('All tickets loaded:', tickets!.dataItems.length);
      console.log('Cinema hall ID from projection:', projection.cinemaHallID);

      console.log('Sample seat from API:', seats!.dataItems[0]);
      this.allSeats = seats!.dataItems.filter(seat => seat.cinemaHallID === projection.cinemaHallID);
      console.log('Filtered seats for this hall:', this.allSeats.length);
      console.log('Sample seats:', this.allSeats.slice(0, 5));

      this.occupiedTickets = tickets!.dataItems.filter(ticket => ticket.projectionID === projectionId);
      console.log('Occupied tickets for this projection:', this.occupiedTickets.length);

      this.processSeatLayout();
      this.calculateTotalPrice();

      this.loading = false;
    } catch (error) {
      console.error('Error loading projection data:', error);
      this.snackBar.open('Error loading projection data', 'Close', { duration: 3000 });
      this.router.navigate(['/public/movies']);
    }
  }

  processSeatLayout(): void {
    console.log('Processing seat layout with', this.allSeats.length, 'seats');

    const seatsWithStatus: SeatWithStatus[] = this.allSeats.map(seat => {
      const isOccupied = this.occupiedTickets.some(ticket => ticket.seatID === seat.id);
      const seatTypeKey = String(seat.seatType);
      const priceMultiplier = this.seatPriceMultipliers[seatTypeKey] || 1.0;

      return {
        ...seat,
        isOccupied,
        isSelected: false,
        priceMultiplier
      };
    });

    const rowDefinitions = [
      {
        rowLetter: 'A',
        seatNumbers: ['A1', 'A2', 'A3', 'A4', 'A5', 'A6', 'A7', 'A8', 'A9', 'A10']
      },
      {
        rowLetter: 'W',
        seatNumbers: ['W1', 'W2', 'B3', 'B4', 'B5', 'B6', 'B7', 'B8', 'B9', 'B10']
      },
      {
        rowLetter: 'C',
        seatNumbers: ['C1', 'C2', 'C3', 'L1', 'L2', 'C6', 'C7', 'C8', 'C9', 'C10']
      },
      {
        rowLetter: 'D',
        seatNumbers: ['D1', 'D2', 'D3', 'D4', 'D5', 'L3', 'L4', 'D8', 'D9', 'D10']
      },
      {
        rowLetter: 'E',
        seatNumbers: ['E1', 'E2', 'E3', 'E4', 'E5', 'E6', 'E7', 'E8', 'E9', 'E10']
      },
      {
        rowLetter: 'F',
        seatNumbers: ['F1', 'F2', 'F3', 'L5', 'L6', 'L7', 'L8', 'F8', 'F9', 'F10']
      }
    ];

    this.seatRows = rowDefinitions.map(rowDef => {
      const rowSeats = seatsWithStatus.filter(seat => {
        return rowDef.seatNumbers.includes(seat.seatNumber);
      });

      rowSeats.sort((a, b) => this.compareSeatPositions(a.seatNumber, b.seatNumber));

      return {
        rowLetter: rowDef.rowLetter,
        seats: rowSeats
      };
    }).filter(row => row.seats.length > 0);

    console.log('Processed seat rows:', this.seatRows.length);
    console.log('Seat rows data:', this.seatRows);

    if (this.seatRows.length > 0 && this.seatRows[0].seats.length > 0) {
      const sampleSeat = this.seatRows[0].seats[0];
      console.log('Sample seat:', sampleSeat);
      console.log('Sample seat type:', sampleSeat.seatType, typeof sampleSeat.seatType);
      console.log('Sample seat type name:', this.getSeatTypeName(sampleSeat.seatType));
      console.log('Sample seat class:', this.getSeatClass(sampleSeat));
      console.log('Sample seat icon:', this.getSeatIcon(sampleSeat));
      console.log('Sample price multiplier:', sampleSeat.priceMultiplier);
    }
  }

  extractRowLetter(seatNumber: string): string {
    return seatNumber.replace(/[0-9]/g, '');
  }

  compareSeatNumbers(a: string, b: string): number {
    const numA = parseInt(a.replace(/[^0-9]/g, '')) || 0;
    const numB = parseInt(b.replace(/[^0-9]/g, '')) || 0;
    return numA - numB;
  }

  compareSeatPositions(a: string, b: string): number {
    // Define seat position mapping based on the actual cinema layout
    const seatPositions: { [key: string]: number } = {
      // Row A: A1-A10
      'A1': 1, 'A2': 2, 'A3': 3, 'A4': 4, 'A5': 5, 'A6': 6, 'A7': 7, 'A8': 8, 'A9': 9, 'A10': 10,

      // Row W+B: W1, W2, B3-B10
      'W1': 1, 'W2': 2, 'B3': 3, 'B4': 4, 'B5': 5, 'B6': 6, 'B7': 7, 'B8': 8, 'B9': 9, 'B10': 10,

      // Row C+L: C1-C3, L1-L2, C6-C10 (L1-L2 are in positions 4-5)
      'C1': 1, 'C2': 2, 'C3': 3, 'L1': 4, 'L2': 5, 'C6': 6, 'C7': 7, 'C8': 8, 'C9': 9, 'C10': 10,

      // Row D+L: D1-D5, L3-L4, D8-D10 (L3-L4 are in positions 6-7)
      'D1': 1, 'D2': 2, 'D3': 3, 'D4': 4, 'D5': 5, 'L3': 6, 'L4': 7, 'D8': 8, 'D9': 9, 'D10': 10,

      // Row E: E1-E10
      'E1': 1, 'E2': 2, 'E3': 3, 'E4': 4, 'E5': 5, 'E6': 6, 'E7': 7, 'E8': 8, 'E9': 9, 'E10': 10,

      // Row F+L: F1-F3, L5-L8, F8-F10 (L5-L8 are in positions 4-7)
      'F1': 1, 'F2': 2, 'F3': 3, 'L5': 4, 'L6': 5, 'L7': 6, 'L8': 7, 'F8': 8, 'F9': 9, 'F10': 10
    };

    const posA = seatPositions[a] || 999;
    const posB = seatPositions[b] || 999;

    return posA - posB;
  }

  compareRowLetters(a: string, b: string): number {
    // Custom sorting to put wheelchair (W) and love (L) seats in proper order
    const order = ['A', 'W', 'B', 'C', 'L', 'D', 'E', 'F'];
    const indexA = order.indexOf(a);
    const indexB = order.indexOf(b);

    if (indexA === -1 && indexB === -1) return a.localeCompare(b);
    if (indexA === -1) return 1;
    if (indexB === -1) return -1;

    return indexA - indexB;
  }

  onSeatClick(seat: SeatWithStatus): void {
    if (!this.isLoggedIn) {
      this.snackBar.open(this.translate.instant('SEAT_SELECTION.LOGIN_REQUIRED'), 'Close', { duration: 3000 });
      return;
    }

    if (seat.isOccupied) {
      this.snackBar.open('This seat is already taken', 'Close', { duration: 2000 });
      return;
    }

    if (seat.isSelected) {
      // Deselect seat
      seat.isSelected = false;
      this.selectedSeats = this.selectedSeats.filter(s => s.id !== seat.id);
    } else {
      // Check if we can select more seats
      if (this.selectedSeats.length >= this.ticketQuantity) {
        this.snackBar.open(`You can only select ${this.ticketQuantity} seat(s)`, 'Close', { duration: 2000 });
        return;
      }

      // Select seat
      seat.isSelected = true;
      this.selectedSeats.push(seat);
    }

    this.calculateTotalPrice();
  }

  onTicketQuantityChange(): void {
    // Ensure ticket quantity is at least 1
    if (this.ticketQuantity < 1) {
      this.ticketQuantity = 1;
    }

    // If we have more selected seats than tickets, deselect excess seats
    if (this.selectedSeats.length > this.ticketQuantity) {
      const excessSeats = this.selectedSeats.slice(this.ticketQuantity);
      excessSeats.forEach(seat => seat.isSelected = false);
      this.selectedSeats = this.selectedSeats.slice(0, this.ticketQuantity);
    }

    this.calculateTotalPrice();
  }

  calculateTotalPrice(): void {
    this.totalPrice = this.selectedSeats.reduce((total, seat) => {
      return total + (this.basePrice * seat.priceMultiplier);
    }, 0);
  }

  getSeatClass(seat: SeatWithStatus): string {
    if (seat.isOccupied) return 'seat occupied';
    if (seat.isSelected) return 'seat selected';
    const seatTypeClass = this.getSeatTypeName(seat.seatType).toLowerCase();
    return `seat available ${seatTypeClass}`;
  }

  getSeatTypeName(seatType: string | number): string {
    // Convert enum values to string names
    if (typeof seatType === 'number' || !isNaN(Number(seatType))) {
      const enumValue = Number(seatType);
      switch (enumValue) {
        case 1: return 'Regular';
        case 2: return 'Love';
        case 3: return 'Wheelchair';
        default: return 'Regular';
      }
    }
    // If it's already a string, return as is
    return String(seatType);
  }

  getSeatIcon(seat: SeatWithStatus): string {
    const seatTypeName = this.getSeatTypeName(seat.seatType);
    switch (seatTypeName) {
      case 'Love': return 'favorite';
      case 'Wheelchair': return 'accessible';
      default: return 'event_seat';
    }
  }

  formatTime(dateTime: string): string {
    return new Date(dateTime).toLocaleTimeString('bs-BA', {
      hour: '2-digit',
      minute: '2-digit'
    });
  }

  formatDate(dateTime: string): string {
    return new Date(dateTime).toLocaleDateString('bs-BA', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric'
    });
  }

  getMovieImage(): string {
    return this.movie?.poster ? `data:image/jpeg;base64,${this.movie.poster}` : '/assets/default-movie.jpg';
  }

  onImageError(event: Event): void {
    const target = event.target as HTMLImageElement;
    if (target) {
      target.src = '/assets/default-movie.jpg';
    }
  }

  canProceedToCheckout(): boolean {
    const canProceed = this.selectedSeats.length === this.ticketQuantity && this.ticketQuantity > 0;
    console.log('Can proceed to checkout:', canProceed, 'Selected seats:', this.selectedSeats.length, 'Ticket quantity:', this.ticketQuantity);
    return canProceed;
  }

  async onReserveTickets(): Promise<void> {
    if (!this.isLoggedIn) {
      this.snackBar.open(this.translate.instant('SEAT_SELECTION.LOGIN_REQUIRED'), 'Close', { duration: 3000 });
      return;
    }

    if (!this.canProceedToCheckout()) {
      this.snackBar.open(this.translate.instant('SEAT_SELECTION.PLEASE_SELECT_SEATS'), 'Close', { duration: 3000 });
      return;
    }

    try {
      const authInfo = this.authService.getMyAuthInfo();
      if (!authInfo) {
        this.snackBar.open(this.translate.instant('SEAT_SELECTION.LOGIN_REQUIRED'), 'Close', { duration: 3000 });
        return;
      }
      const currentUserId = authInfo.userId;

      const ticketPromises = this.selectedSeats.map(seat => {
        const ticketRequest: TicketUpdateOrInsertRequest = {
          orderDate: new Date().toISOString(),
          projectionId: this.projection!.id,
          seatId: seat.id,
          myAppUserId: currentUserId,
          paid: false, // Initially reserved, not paid
          tenantId: 1
        };
        return this.ticketCreateService.handleAsync(ticketRequest).toPromise();
      });

      // Wait for all tickets to be created
      await Promise.all(ticketPromises);

      // Show success message
      const successMessage = this.translate.instant('SEAT_SELECTION.RESERVATION_SUCCESS', {
        count: this.selectedSeats.length,
        seats: this.selectedSeats.map(s => s.seatNumber).join(', '),
        total: this.totalPrice.toFixed(2)
      });

      this.snackBar.open(successMessage, 'Close', { duration: 5000 });

      // Navigate to movie reservations tab
      setTimeout(() => {
        this.router.navigate(['/client/reservations'], { fragment: 'movies' });
      }, 2000);

    } catch (error) {
      console.error('Error creating reservations:', error);
      this.snackBar.open(this.translate.instant('SEAT_SELECTION.RESERVATION_ERROR'), 'Close', { duration: 3000 });
    }
  }

  getSeatTooltip(seat: SeatWithStatus): string {
    if (seat.isOccupied) {
      return 'This seat is taken';
    }
    if (seat.isSelected) {
      return `Selected - ${seat.seatNumber} (${seat.seatType})`;
    }
    const price = this.basePrice * seat.priceMultiplier;
    return `${seat.seatNumber} - ${seat.seatType} - ${price.toFixed(2)} KM`;
  }

  shouldAddGap(seat: SeatWithStatus, allSeats: SeatWithStatus[]): boolean {
    const currentIndex = allSeats.indexOf(seat);
    if (currentIndex === 0) return false;

    const previousSeat = allSeats[currentIndex - 1];

    // Define where gaps should appear based on the cinema layout
    const gapPositions = [
      // Row W+B: gap after W2 (before B3)
      { previous: 'W2', current: 'B3' },
      // Row C+L: gap after C3 (before L1) and after L2 (before C6)
      { previous: 'C3', current: 'L1' },
      { previous: 'L2', current: 'C6' },
      // Row D+L: gap after D5 (before L3) and after L4 (before D8)
      { previous: 'D5', current: 'L3' },
      { previous: 'L4', current: 'D8' },
      // Row F+L: gap after F3 (before L5) and after L8 (before F8)
      { previous: 'F3', current: 'L5' },
      { previous: 'L8', current: 'F8' }
    ];

    return gapPositions.some(gap =>
      gap.previous === previousSeat.seatNumber && gap.current === seat.seatNumber
    );
  }

  onBackToMovies(): void {
    this.router.navigate(['/public/movies']);
  }
}
