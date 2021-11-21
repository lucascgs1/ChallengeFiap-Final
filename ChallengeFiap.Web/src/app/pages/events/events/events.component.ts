// mock
import { events } from '../../../core/mock/events.mock';

// service
import { EventsService } from '../../../core/services/eventos.service';

// package
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  public evento: any[] = [];

  constructor(
    public eventsService: EventsService
  ) { }

  ngOnInit(): void {
    this.getEvents();
  }


  getEvents() {
    this.eventsService.getAllEvents()
      .subscribe(
        res => {
          console.log(res);
          this.evento = res;

        }
      )

      ;
  }
}
