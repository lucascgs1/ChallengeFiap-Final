import { Component, OnInit } from '@angular/core';
import { EventDetails } from '../../../core/model/events';
import { EventsService } from '../../../core/services/eventos.service';

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
    public eventsService: EventsService
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
}
