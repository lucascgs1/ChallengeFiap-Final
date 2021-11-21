// mock
import { events } from '../../../core/mock/events.mock';

// service
import { EventsService } from '../../../core/services/eventos.service';

// package
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  public evento: any[] = [];

  constructor(
    public eventsService: EventsService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
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

  goDetails(id: number) {
    this.router.navigate(['events/' + id]);
  }
}
