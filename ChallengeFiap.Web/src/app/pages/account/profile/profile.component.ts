import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../core/services/usuario.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public profile: any = null;


  constructor(
    public usuarioService: UsuarioService
  ) { }

  ngOnInit(): void {
    this.getProfile()
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
