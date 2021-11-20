import { TestBed } from '@angular/core/testing';

import { HttpClienteService } from './http-cliente.service';

describe('HttpClienteService', () => {
  let service: HttpClienteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpClienteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
