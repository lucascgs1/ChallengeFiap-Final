import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsBookingComponent } from './events-booking.component';

describe('EventsBookingComponent', () => {
  let component: EventsBookingComponent;
  let fixture: ComponentFixture<EventsBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventsBookingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
