import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-card-events',
  templateUrl: './card-events.component.html',
  styleUrls: ['./card-events.component.scss']
})
export class CardEventsComponent implements OnInit {
  @Input() evento: any;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    console.log(this.evento);
  }

  goDetails() {
    this.router.navigate(['events/' + this.evento.id]);
  }
}
