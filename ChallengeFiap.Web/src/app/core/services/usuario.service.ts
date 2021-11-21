// model
import { Usuario } from '../model/usuario';

//mock
import { events } from '../mock/events.mock';

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
export class UsuarioService {
  constructor(
    private httpClient: HttpClient,
    private _http: HttpClienteService
  ) { }

  getUsuarioById(id: number): Observable<Usuario> {

    return this._http.get<Usuario>({ url: environment.endPoints.usuario + '/' + id, cacheMins: 10 })
  }

  getAllUsuario(): Observable<Usuario[]> {

    return this.httpClient.get<Usuario[]>(environment.endPoints.usuario)
      .pipe(
        retry(2),
        catchError(this._http.handleError));
  }


  postUsuario(usuario: Usuario): Observable<any> {

    let url = environment.endPoints.usuario;

    if (usuario.id == 0) {
      url += '/cadastro'
    }
    return this._http.get<any>({ url: 'https://example-api/products', cacheMins: 5 })
  }


  putCliente(usuario: Usuario): Observable<any> {

    return this._http.put({ url: environment.endPoints.usuario, body: usuario, cacheMins: 10 })
      .pipe(
        retry(2),
        catchError(this._http.handleError));
  }

  deleteClienteById(id: number): Observable<Usuario> {

    return this._http.delete<Usuario>({ url: environment.endPoints.usuario + '/' + id, cacheMins: 0 })
      .pipe(
        retry(2),
        catchError(this._http.handleError));
  }
}
