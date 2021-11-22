import { Component, OnInit } from '@angular/core';
import { EventDetails } from '../../../core/model/events';
// service
import { EventsService } from '../../../core/services/eventos.service';

// package
import { MatDialog } from '@angular/material/dialog';
import { EventsBookingComponent } from '../events-booking/events-booking.component';
@Component({
  selector: 'app-events-detail',
  templateUrl: './events-detail.component.html',
  styleUrls: ['./events-detail.component.scss']
})
export class EventsDetailComponent implements OnInit {
  teste = 'Usuario';
  public event!: EventDetails;
  public eventId: number = 0;

  constructor(
    public eventsService: EventsService,
    public dialog: MatDialog
  ) { }
  ngOnInit(): void {
    this.getEventDetails();
  }

  getEventDetails() {
    this.eventsService.getEventDetailById(this.eventId)
      .subscribe(
        res => {
          console.log(res);

          this.event = res;
        });
  }

  irPerfilUsuario(id: number) {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(EventsBookingComponent, {
      width: '500px',
      data: {},
    });

    dialogRef.afterClosed()
      .subscribe(
        result => {
          console.log('The dialog was closed');
          console.log(result);

          if (result)
            this.eventsService.postBookEvent(this.eventId)
              .subscribe(
                result => {

                }
              );
          //this.animal = result;
        });
  }
}
