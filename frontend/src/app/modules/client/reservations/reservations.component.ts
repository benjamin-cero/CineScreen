import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';
import { OrderGetAllEndpointService, OrderGetAllResponse } from '../../../endpoints/order-endpoints/order-get-all-endpoint.service';
import { OrderDeleteEndpointService } from '../../../endpoints/order-endpoints/order-delete-endpoint.service';
import { TicketGetAllEndpointService, TicketGetAllResponse } from '../../../endpoints/ticket-endpoints/ticket-get-all-endpoint.service';
import { TicketDeleteEndpointService } from '../../../endpoints/ticket-endpoints/ticket-delete-endpoint.service';
import { MyAuthService } from '../../../services/auth-services/my-auth.service';

interface MovieReservation {
  id: string;
  movieTitle: string;
  projectionStartTime: string;
  cinemaHallName: string;
  orderDate: string;
  paid: boolean;
  seats: string[];
  totalPrice: number;
  ticketCount: number;
  tickets: TicketGetAllResponse[];
}

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css'],
  standalone: false
})
export class ReservationsComponent implements OnInit {
  foodOrders: OrderGetAllResponse[] = [];
  movieTickets: TicketGetAllResponse[] = [];
  movieReservations: MovieReservation[] = [];
  
  userOrders: OrderGetAllResponse[] = [];
  
  isLoadingOrders = true;
  isLoadingTickets = true;
  
  cancellingOrderId: number | null = null;
  cancellingReservationId: string | null = null;
  
  selectedTabIndex = 0;

  constructor(
    private orderService: OrderGetAllEndpointService,
    private orderDeleteService: OrderDeleteEndpointService,
    private ticketService: TicketGetAllEndpointService,
    private ticketDeleteService: TicketDeleteEndpointService,
    private snackBar: MatSnackBar,
    private translate: TranslateService,
    private route: ActivatedRoute,
    private authService: MyAuthService
  ) {}

  ngOnInit(): void {
    this.loadUserOrders();
    this.loadUserTickets();
    
    this.route.fragment.subscribe(fragment => {
      if (fragment === 'movies') {
        this.selectedTabIndex = 1;
      }
    });
  }

  loadUserOrders(): void {
    this.isLoadingOrders = true;
    
    this.orderService.handleAsync({
      pageNumber: 1,
      pageSize: 1000,
      q: ''
    }).subscribe({
      next: (response) => {
        this.foodOrders = response.dataItems;
        this.userOrders = this.foodOrders;
        this.isLoadingOrders = false;
      },
      error: (error) => {
        console.error('Error loading orders:', error);
        this.isLoadingOrders = false;
      }
    });
  }

  loadUserTickets(): void {
    this.isLoadingTickets = true;
    
    this.ticketService.handleAsync({
      pageNumber: 1,
      pageSize: 1000,
      q: ''
    }).subscribe({
      next: (response) => {
        this.movieTickets = response.dataItems;
        this.groupTicketsIntoReservations();
        this.isLoadingTickets = false;
      },
      error: (error) => {
        console.error('Error loading tickets:', error);
        this.isLoadingTickets = false;
      }
    });
  }

  groupTicketsIntoReservations(): void {
    const reservationGroups = new Map<string, TicketGetAllResponse[]>();
    
    this.movieTickets.forEach(ticket => {
      const orderTime = new Date(ticket.orderDate);
      const roundedTime = new Date(Math.floor(orderTime.getTime() / (5 * 60 * 1000)) * (5 * 60 * 1000));
      const groupKey = `${ticket.projectionID}-${ticket.movieTitle}-${roundedTime.getTime()}`;
      
      if (!reservationGroups.has(groupKey)) {
        reservationGroups.set(groupKey, []);
      }
      reservationGroups.get(groupKey)!.push(ticket);
    });

    this.movieReservations = Array.from(reservationGroups.entries()).map(([groupKey, tickets]) => {
      const firstTicket = tickets[0];
      const totalPrice = tickets.reduce((sum, ticket) => sum + ticket.ticketPrice, 0);
      const seats = tickets.map(ticket => ticket.seatNumber).sort();
      
      return {
        id: groupKey,
        movieTitle: firstTicket.movieTitle,
        projectionStartTime: firstTicket.projectionStartTime,
        cinemaHallName: firstTicket.cinemaHallName,
        orderDate: firstTicket.orderDate,
        paid: false,
        seats: seats,
        totalPrice: totalPrice,
        ticketCount: tickets.length,
        tickets: tickets
      };
    }).sort((a, b) => new Date(b.orderDate).getTime() - new Date(a.orderDate).getTime());
  }

  getReservationNumber(index: number): string {
    return this.translate.instant('RESERVATIONS.MOVIE_SECTION.RESERVATION_NUMBER', { number: index });
  }

  cancelReservation(order: OrderGetAllResponse): void {
    this.cancellingOrderId = order.id;
    
    this.orderDeleteService.handleAsync(order.id).subscribe({
      next: () => {
        this.snackBar.open(
          this.translate.instant('RESERVATIONS.FOOD_SECTION.CANCEL_SUCCESS'),
          this.translate.instant('COMMON.CLOSE'),
          { duration: 3000 }
        );
        this.loadUserOrders();
        this.cancellingOrderId = null;
      },
      error: (error) => {
        console.error('Error cancelling order:', error);
        this.snackBar.open(
          this.translate.instant('RESERVATIONS.FOOD_SECTION.CANCEL_ERROR'),
          this.translate.instant('COMMON.CLOSE'),
          { duration: 3000 }
        );
        this.cancellingOrderId = null;
      }
    });
  }

  cancelMovieReservation(reservation: MovieReservation): void {
    this.cancellingReservationId = reservation.id;
    
    const deletePromises = reservation.tickets.map(ticket => 
      this.ticketDeleteService.handleAsync(ticket.id).toPromise()
    );

    Promise.all(deletePromises).then(() => {
      this.snackBar.open(
        this.translate.instant('RESERVATIONS.MOVIE_SECTION.CANCEL_SUCCESS'),
        this.translate.instant('COMMON.CLOSE'),
        { duration: 3000 }
      );
      this.loadUserTickets();
      this.cancellingReservationId = null;
    }).catch((error) => {
      console.error('Error cancelling movie reservation:', error);
      this.snackBar.open(
        this.translate.instant('RESERVATIONS.MOVIE_SECTION.CANCEL_ERROR'),
        this.translate.instant('COMMON.CLOSE'),
        { duration: 3000 }
      );
      this.cancellingReservationId = null;
    });
  }
}
