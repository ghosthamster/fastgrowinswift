import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { UserDTO } from '../shared/interfaces/user.interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  userForm: FormGroup;
  errorMessage = '';
  user: UserDTO;

  constructor(private formBuilder: FormBuilder,
              private authService: AccountService,
              private router: Router) { }

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      userName: [ null, [ Validators.required, Validators.maxLength(50) ] ],
      password: [ null, [ Validators.required, Validators.maxLength(50), Validators.minLength(5) ] ],
      repeatPassword: [ null, [ Validators.required, Validators.maxLength(50), Validators.minLength(5)] ]
    }, { validators: this.checkPasswords });
  }

  register() {
    this.user = {
      login: this.userForm.get('userName').value,
      password: this.userForm.get('password').value
    };

    if (this.userForm.valid) {
      this.authService.registerUser(this.user).subscribe(response => {
        this.authService.loggedIn = true;
        this.authService.userId = response;
        this.authService.userName = this.userForm.get('userName').value;
        this.authService.userChanged.next(response);
        this.router.navigateByUrl('/choose-task');
      }, () => {
        this.errorMessage = 'У доступі до системи відмовлено. Перевірте дані і спробуйте знову';
        this.scrollToError();
      });
    } else {
      this.errorMessage = 'Будь ласка, заповніть всі необхідні поля!';
      this.scrollToError();
    }
  }

  checkPasswords: ValidatorFn = (form):  ValidationErrors | null => {
    return form.value?.password === form.value?.repeatPassword ? null : { notSame: true }
  }

  scrollToError(): void {
    const errorField = document.querySelector('.mat-error');
    errorField.scrollIntoView({ behavior: 'smooth' });
  }

}
