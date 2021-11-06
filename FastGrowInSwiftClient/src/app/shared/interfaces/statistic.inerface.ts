export interface Statistic {
  title: string;
  mark: number;
  attemptSequence: number;
  dateOfAnswer: Date;
  statisticItems: StatisticItem[];
}

export interface StatisticItem {
  taskTitle: string;
  dificultyCoef: number;
  mark: number;
  markInfluence: number;
}
