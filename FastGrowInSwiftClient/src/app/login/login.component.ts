import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserDTO } from '../shared/interfaces/user.interface';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userForm: FormGroup;
  errorMessage = '';
  user: UserDTO;

  constructor(private formBuilder: FormBuilder,
              private authService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      userName: [ null, [ Validators.required, Validators.maxLength(50) ] ],
      password: [ null, [ Validators.required, Validators.maxLength(50) ] ],
    });
  }

  login(): void {
    this.user = {
      login: this.userForm.get('userName').value,
      password: this.userForm.get('password').value
    };

    if (this.userForm.valid) {
      this.authService.login(this.user).subscribe(response => {
        this.authService.loggedIn = true;
        this.authService.userId = response;
        this.authService.userName = this.userForm.get('userName').value;
        this.authService.userChanged.next(response);
        this.router.navigateByUrl('/choose-task');
      }, error => {
        console.log(error);
        this.errorMessage = 'У доступі до системи відмовлено. Перевірте дані і спробуйте знову';
        this.scrollToError();
      });
    } else {
      console.log(this.userForm);
      this.errorMessage = 'Будь ласка, заповніть всі необхідні поля!';
      this.scrollToError();
    }
  }

  scrollToError(): void {
    const errorField = document.querySelector('.mat-error');
    errorField.scrollIntoView({ behavior: 'smooth' });
  }
}
