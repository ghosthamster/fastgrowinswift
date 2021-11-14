import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChooseTaskComponent } from './choose-task/choose-task.component';
import { StatisticComponent } from './statistic/statistic.component';
import { PerformTaskComponent } from './perform-task/perform-task.component';
import { LoginComponent } from './login/login.component';
import { TaskResultsComponent } from './task-results/task-results.component';
import { AuthGuardService } from './services/auth-guard.service';
import { RegisterComponent } from './register/register.component';
import { CreateTaskComponent } from './create-task/create-task.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'choose-task',
    component: ChooseTaskComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'create-task',
    component: CreateTaskComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'perform-task/:titleId',
    component: PerformTaskComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'task-results',
    component: TaskResultsComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'statistic',
    component: StatisticComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
