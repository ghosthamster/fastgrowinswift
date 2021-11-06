import { Component, OnInit } from '@angular/core';
import { AnswerService } from '../services/answer.service';
import { AnswerDTO } from '../shared/interfaces/answer.interface';
import { AccountService } from '../services/account.service';
import { TaskService } from '../services/task.service';
import { TitleDTO } from '../shared/interfaces/task.interface';

@Component({
  selector: 'app-task-results',
  templateUrl: './task-results.component.html',
  styleUrls: ['./task-results.component.scss']
})
export class TaskResultsComponent implements OnInit {
  displayedColumns: string[] = [ 'index', 'content', 'mark'];
  answers: AnswerDTO[];
  isLoading = true;
  taskNameLength = 60;
  allTiles: TitleDTO[];
  averageCorectnessPercent = 0;

  constructor(private answerService: AnswerService, private taskService: TaskService, private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.isLoading = true;

    this.taskService.getAllTitles().subscribe(res => {
      this.allTiles = res;
    });

    this.answerService.getLastAnswer(this.accountService.userId).subscribe(res => {
      res.forEach(a => {
        this.averageCorectnessPercent += a.correctnessPercent;
        a.answerItems.sort((ai1, ai2) => ai1.order - ai2.order);
      });
      this.averageCorectnessPercent = this.averageCorectnessPercent / res.length;

      this.answers = res;

      this.isLoading = false;
    }, error => {
      console.log(error);
      this.isLoading = false;
    });
  }
}
