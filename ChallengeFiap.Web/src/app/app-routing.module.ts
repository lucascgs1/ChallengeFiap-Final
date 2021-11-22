// pages
import { LoginComponent } from './pages/account/login/login.component';
import { ProfileComponent } from './pages/account/profile/profile.component';
import { RegisterComponent } from './pages/account/register/register.component';
import { EventsDetailComponent } from './pages/events/events-detail/events-detail.component';
import { EventsComponent } from './pages/events/events/events.component';
import { MyEventComponent } from './pages/events/my-event/my-event.component';
import { NotFoundComponent } from './pages/account/not-found/not-found.component';

// packages
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'events',
    pathMatch: 'full'
  },
  {
    path: 'events',
    component: EventsComponent
  },
  {
    path: 'events/:id',
    component: EventsDetailComponent
  },
  {
    path: 'my-events',
    component: MyEventComponent
  },
  {
    path: 'account/login',
    component: LoginComponent
  },
  {
    path: 'account/register',
    component: RegisterComponent
  },
  {
    path: 'account/profile',
    component: ProfileComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
