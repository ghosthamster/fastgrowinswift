export interface AnswerDTO {
  id?: number;
  dateOfAnswer?: Date;
  timeOfExecution?: number;
  correctnessPercent?: number;
  userId?: number;
  attemtpSequence?: number;
  taskId?: number;
  answerItems: AnswerItemDTO[];
}

export interface AnswerItemDTO {
  id?: number;
  content?: string;
  order?: number;
  correctnessPercent?: number;
  answerOptionId?: number;
  answerId?: number;
}
