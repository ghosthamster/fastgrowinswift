import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerformTaskComponent } from './perform-task.component';

describe('PerformTaskComponent', () => {
  let component: PerformTaskComponent;
  let fixture: ComponentFixture<PerformTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PerformTaskComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PerformTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
