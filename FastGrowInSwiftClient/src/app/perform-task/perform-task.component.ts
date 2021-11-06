import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../services/task.service';
import { TaskDTO, TaskItemDTO, TitleDTO } from '../shared/interfaces/task.interface';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { AnswerDTO, AnswerItemDTO } from '../shared/interfaces/answer.interface';
import { AnswerService } from '../services/answer.service';
import { Observable, Subject, Subscription, timer } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EventEmitter } from 'events';
import { ProgressDTO, ProgressItemDTO } from '../shared/interfaces/progress.interface';
import { ProgressService } from '../services/progress.service';
import { AccountService } from '../services/account.service';


@Component({
  selector: 'app-perform-task',
  templateUrl: './perform-task.component.html',
  styleUrls: [ './perform-task.component.scss' ]
})
export class PerformTaskComponent implements OnInit, OnDestroy {
  isLoading = true;
  isComparing = false;
  isCompared = false;
  errorMessage = null;
  currentTasks: TaskDTO[];
  selectedTasks: TaskDTO[] = [];
  answers: AnswerDTO[] = new Array<AnswerDTO>();
  progresses: ProgressDTO[] = [];
  results: AnswerDTO[] = null;
  currentTitle: TitleDTO;
  step = 0;
  timerSubscription: Subscription;

  constructor(private taskService: TaskService,
              private router: Router,
              private route: ActivatedRoute,
              private accountService: AccountService,
              private answerService: AnswerService,
              private progressService: ProgressService) {
  }

  ngOnDestroy(): void {
    if (!this.isCompared) {
      this.selectedTasks.forEach((task) => {
        let progressId = null;
        //if (task.typeId !== 2) {
        if (this.progresses.length > 0) {
          const oldProgress = this.progresses.find(p => p?.taskId === task.id);
          if (oldProgress === null || oldProgress === undefined) {
            progressId = null;
          } else {
            progressId = oldProgress.id;
          }
        }
        // }

        const progress: ProgressDTO =
          {
            id: +progressId,
            userId: this.accountService.userId,
            taskId: task.id,
            timeOfExecution: this.answers.find(e => e.taskId === task.id).timeOfExecution,
            progressItems: []
          };
        task.taskItems.forEach((taskItem, index) => {
          if (task.typeId === 2) {
            progress.progressItems.push({
              content: taskItem.content,
              order: null,
              answerOptionId: taskItem.id
            });
          } else {
            progress.progressItems.push({
              content: taskItem.content,
              order: index + 1,
              answerOptionId: taskItem.id
            });
          }
        });
        console.log(progress);
        this.progressService.addProgress(progress).subscribe(res => {
          console.log(res);
        }, error => {
          console.log(error);
        });
      });
    }
  }

  setStep(index: number): void {
    this.step = index;
  }

  nextStep(): void {
    this.step++;
  }

  prevStep(): void {
    this.step--;
  }

  ngOnInit(): void {
    this.isLoading = true;
    const routeParams = this.route.snapshot.paramMap;
    const titleIdFromRoute = Number(routeParams.get('titleId'));

    this.taskService.getAllTitles()
      .subscribe(data => {
        this.currentTitle = data.find(el => el.id === titleIdFromRoute);
      });

    this.taskService.getByTitleId(titleIdFromRoute, 100, 0)
      .subscribe(data => {
        this.currentTasks = data;
        this.currentTasks.forEach((task, taskIndex) => {
          // if (task.typeId === 2) {
          //   this.selectedTasks.push({
          //     id: task.id,
          //     taskItems: new Array<TaskItemDTO>()
          //   });
          //   task.taskItems[0].content = '';
          //   this.selectedTasks.push({
          //     id: task.id,
          //     taskItems: new Array<TaskItemDTO>()
          //   });
          // }

          const selectedTask: TaskDTO = {
            id: task.id,
            typeId: task.typeId,
            taskItems: new Array<TaskItemDTO>()
          };
          if (task.typeId === 2) {
            task.taskItems[0].content = '';
            selectedTask.taskItems.push({
              content: '',
              taskId: task.id
            });
          }
          this.selectedTasks.push(selectedTask);
          const answer: AnswerDTO = {
            taskId: task.id,
            userId: this.accountService.userId,
            timeOfExecution: 0,
            answerItems: new Array<AnswerItemDTO>()
          };
          this.answers.push(answer);

          this.progressService.getByUserTaskId(this.accountService.userId, task.id).subscribe(res => {
            const progress = res;
            this.progresses.push(res);
            console.log('Progress', progress);

            this.answers.forEach(e => e.timeOfExecution = this.progresses.find(p => p.taskId === e.taskId) ?
              this.progresses.find(p => p.taskId === e.taskId).timeOfExecution : 0);

            progress.progressItems.forEach(progressItem => {
              if (task.typeId === 2) {
                this.selectedTasks[taskIndex].taskItems[0].content = progressItem.content;
              } else {
                const currentIndex = task.taskItems.indexOf(task.taskItems.find(el => el.id === progressItem.answerOptionId));
                const targetIndex = progressItem.order - 1;

                transferArrayItem(task.taskItems,
                  this.selectedTasks[taskIndex].taskItems,
                  currentIndex,
                  targetIndex);
              }
            });


          }, error => {
            console.log(error);
          });
          console.log('currtasks', this.currentTasks);
          console.log('selectedTasks', this.selectedTasks);

          task.taskItems.sort(() => Math.random() - 0.5);
        });


        this.isLoading = false;
        this.startTimer();
      });
  }

  drop(event: CdkDragDrop<TaskItemDTO[]>, array, taskIndex): void {
    this.results = null;
    this.errorMessage = null;
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  compareWithEtalon(): void {
    this.isComparing = true;
    this.errorMessage = null;
    this.answers.forEach(answer => {
      answer.answerItems = [];
    });

    this.selectedTasks.forEach((task, index) => {
      const length = task.taskItems.length;
      if (length === 0 && task.typeId === 1) {
        this.errorMessage = 'Заповніть всі відповіді';
      }
    });

    // this.currentTasks.forEach((task, index) => {
    //   if (task.typeId === 2) {
    //     const taskItem = task.taskItems[0];
    //
    //     let answerItem: AnswerItemDTO;
    //
    //     answerItem = {
    //       content: taskItem.content,
    //       order: null,
    //       answerOptionId: taskItem.id
    //     };
    //
    //     this.answers[index].answerItems.push(answerItem);
    //   }
    // });

    if (this.errorMessage !== null) {
      this.isComparing = false;
      return;
    } else {
      this.selectedTasks.forEach((task, index) => {

        task.taskItems.forEach((taskItem, answerItemOrder) => {
          let answerItem: AnswerItemDTO;
          if (task.typeId === 2) {
            answerItem = {
              content: taskItem.content,
              order: null,
              answerOptionId: null
            };
          } else {
            answerItem = {
              content: taskItem.content,
              order: answerItemOrder + 1,
              answerOptionId: taskItem.id
            };
          }


          this.answers[index].answerItems.push(answerItem);
        });
      });

      this.timerSubscription.unsubscribe();
      this.answerService.createAnswers(this.answers).subscribe(res => {
        console.log(res);
        this.answerService.validateLast(this.accountService.userId).subscribe(answerResult => {
          this.isComparing = false;
          this.results = answerResult;
          this.isCompared = true;
          console.log(answerResult);
          this.router.navigateByUrl('task-results');
        });
      }, error => {
        console.log(error);
        this.isComparing = false;
      });
      console.log(this.answers);
    }
  }

  startTimer(): void {
    this.timerSubscription = timer(0, 1000).subscribe(ellapsedCycles => {
      this.answers[this.step].timeOfExecution += 1000;
    });
  }
}
