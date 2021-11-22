// pages
import { AppComponent } from './app.component';;
import { LoginComponent } from './pages/account/login/login.component';
import { RegisterComponent } from './pages/account/register/register.component';
import { ProfileComponent } from './pages/account/profile/profile.component';
import { EventsComponent } from './pages/events/events/events.component';
import { EventsDetailComponent } from './pages/events/events-detail/events-detail.component';
import { EventsBookingComponent } from './pages/events/events-booking/events-booking.component';
import { MyEventComponent } from './pages/events/my-event/my-event.component';

// module
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';

// package
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotFoundComponent } from './pages/account/not-found/not-found.component';
import { RouterModule } from '@angular/router';
import { IConfig, NgxMaskModule } from 'ngx-mask';


@NgModule({
  declarations: [
    AppComponent,
    EventsDetailComponent,
    EventsComponent,
    MyEventComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    NotFoundComponent,
    EventsBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule,
    NgxMaskModule.forRoot({ dropSpecialCharacters: false }),
  ],
  exports: [
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
