import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { map, startWith, switchMap } from 'rxjs/operators';
import { TaskService } from '../services/task.service';
import { TitleDTO } from '../shared/interfaces/task.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-choose-task',
  templateUrl: './choose-task.component.html',
  styleUrls: ['./choose-task.component.scss']
})
export class ChooseTaskComponent implements AfterViewInit {
  displayedColumns: string[] = ['id', 'titleName', 'button'];
  titles: TitleDTO[] = [];
  isLoadingResults = true;

  @ViewChild(MatSort) sort: MatSort;

  constructor(private taskService: TaskService, private router: Router) { }

  ngAfterViewInit(): void {
    this.sort.sortChange
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.taskService.getAllTitles();
        }),
        map(data => {
          this.isLoadingResults = false;
          return data;
        })
      ).subscribe(data => this.titles = data, () => this.isLoadingResults = false);
  }

  chooseTheme(titleId: number): void {
    this.router.navigateByUrl(`perform-task/${titleId}`);
  }
}
