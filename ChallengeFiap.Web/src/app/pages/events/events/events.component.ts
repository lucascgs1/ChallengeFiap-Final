// mock
import { events } from '../../../core/mock/events.mock';

// service
import { EventsService } from '../../../core/services/eventos.service';

// package
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from 'src/app/core/services/usuario.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  public evento: any[] = [];
  public profile: any;

  constructor(
    public eventsService: EventsService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private usuarioService: UsuarioService,
  ) { }

  ngOnInit(): void {
    this.getEvents();
    this.getProfile();
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

  getProfile() {
    this.usuarioService.getUserProfile()
      .subscribe(
        result => {
          this.profile = result;
        }
      )
  }
}
