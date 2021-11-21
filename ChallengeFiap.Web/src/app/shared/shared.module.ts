// components
import { CardEventsComponent } from './components/card-events/card-events.component';

// module
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

// package
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';


@NgModule({
  declarations: [
    CardEventsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    SweetAlert2Module.forRoot(),
  ],
  exports: [
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,

    CardEventsComponent,
    SweetAlert2Module,
  ]
})
export class SharedModule { }
