import { Component, OnInit } from '@angular/core';
import { StatisticService } from '../services/statistic.service';
import { Statistic } from '../shared/interfaces/statistic.inerface';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: [ './statistic.component.scss' ]
})
export class StatisticComponent implements OnInit {
  displayedColumns: string[] = [ 'index', 'taskTitle', 'difficultyCoef', 'mark', 'timeOfExecution', 'markInfluence'];
  statistics: Statistic[];
  isLoading = true;
  taskNameLength = 60;
  constructor(private statisticService: StatisticService,
              private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.isLoading = true;

    this.statisticService.getStatistic(this.accountService.userId).subscribe(res => {
      this.statistics = res;
      this.isLoading = false;
    }, error => {
      console.log(error);
      this.isLoading = false;
    });
  }

}
