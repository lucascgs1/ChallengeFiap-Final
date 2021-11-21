// model
import { EventDetails, Events } from '../model/events';

//mock
import { events } from '../mock/events.mock';
import { eventDetail } from '../mock/event-detail.mock';

// module
import { environment } from '../../../environments/environment';
import { HttpClienteService } from './util/http-cliente.service';

// package
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { retry, catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';
import { useAnimation } from '@angular/animations';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(
    private _http: HttpClienteService
  ) { }


  getAllEvents(): Observable<Events[]> {

    return of(events);

    return this._http.get<Events[]>({ url: environment.endPoints.evento, cacheMins: 10 })
  }


  getEventDetailById(idEvent: number): Observable<EventDetails> {

    return of(eventDetail);

    return this._http.get<EventDetails>({ url: environment.endPoints.evento, cacheMins: 10 })
  }

}
