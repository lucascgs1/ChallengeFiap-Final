// model
import { EventBooking } from '../../../core/model/events';

// package
import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-events-booking',
  templateUrl: './events-booking.component.html',
  styleUrls: ['./events-booking.component.scss']
})
export class EventsBookingComponent {

  constructor(
    public dialogRef: MatDialogRef<EventsBookingComponent>,
    @Inject(MAT_DIALOG_DATA)  public data: EventBooking,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
