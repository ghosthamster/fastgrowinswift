export interface ProgressDTO {
  id?: number;
  savingDate?: Date;
  timeOfExecution?: number;
  userId?: number;
  taskId?: number;
  progressItems: ProgressItemDTO[];
}

export interface ProgressItemDTO {
  id?: number;
  content?: string;
  order?: number;
  progressId?: number;
  answerOptionId?: number;
}
