import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/interfaces/login-request';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public isDisabled: boolean = false;
  public loginRequest: LoginRequest = {
    username: '',
    password: '',
  };
  public error: boolean | string = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  doLogin(): void {
    this.error = false;
    this.authService.login(this.loginRequest).subscribe((response: any) =>{
      if (response && response.token) {
        localStorage.setItem('token', response.token)
        localStorage.setItem('username', response.username);
        this.router.navigate(['/dashboard']);
      } else {
        this.error = 'Authentication failed!';
      }
    });
  }
}
