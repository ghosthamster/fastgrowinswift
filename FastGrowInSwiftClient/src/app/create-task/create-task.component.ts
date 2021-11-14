import { TaskService } from './../services/task.service';
import { TaskDTO } from './../shared/interfaces/task.interface';
import { FormArray, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.scss']
})
export class CreateTaskComponent implements OnInit {

  createForm = new FormGroup({
    TitleName: new FormControl(null, Validators.required),
    content: new FormControl(null, Validators.required),
    dificultyCoef: new FormControl(null, Validators.required),
    taskItems: new FormArray([], this.minMaxLengthArray(2, 6))
  });

  get taskItems() {
    return this.createForm.controls.taskItems as FormArray;
  }

  constructor(private readonly taskService: TaskService) {}

  initAnswerControl() {
    return new FormGroup({
      content: new FormControl(null, Validators.required),
      order: new FormControl(null)
    });
  }

  addAnswer() {
    const group = this.initAnswerControl();
    group.setParent(this.taskItems);
    this.taskItems.push(group);
  }

  removeAnswer(i) {
    this.taskItems.removeAt(i);
  }

  minMaxLengthArray(min: number, max: number): ValidatorFn {
    return (c): {[key: string]: any} => {
        if (c.value.length >= min && c.value.length <= max)
            return null;

        return { 'minLengthArray': {valid: false }};
    }
  }

  ngOnInit(): void {
  }

  createTask() {
    if (this.createForm.invalid) { return; }

    this.taskService.createTitle({ titleName: this.createForm.value.TitleName })
    .pipe(switchMap(titleId => {
      const task: TaskDTO = {
        ...this.createForm.value,
        typeId: 1,
        TitleId: titleId,
        taskItems: this.taskItems.value.map((item, i) => ({ ...item, order: i+1}))
      }

      return this.taskService.createTask(task);
    })).subscribe(res => { console.log(res)});

  }

}
