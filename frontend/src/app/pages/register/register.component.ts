import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from "@angular/forms";
import { Router } from '@angular/router';
import { RegisterRequest } from 'src/app/interfaces/register-request';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  public error: boolean | string = false;
  public isDisabled: boolean = false;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(32)]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  doRegister() {
    var registerRequest: RegisterRequest = {
      username: this.registerForm.get('username')?.value,
      password: this.registerForm.get('password')?.value,
      email: this.registerForm.get('email')?.value,
      firstName: '',
      lastName: ''
    };
    console.log(registerRequest);
    this.authService.register(registerRequest).subscribe((response: any) => {
      if (response && response.token) {
        localStorage.setItem('token', response.token)
        localStorage.setItem('username', response.username);
        this.router.navigate(['/dashboard']);
      } else {
        this.error = 'Register failed!';
      }
    });
  }
}
