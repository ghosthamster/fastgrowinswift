export interface TaskDTO {
  id?: number;
  content?: string;
  dificultyCoef?: number;
  typeId?: number;
  typeName?: string;
  TitleId?: number;
  TitleName?: string;
  taskItems: TaskItemDTO[];
}

export interface TaskItemDTO {
  id?: number;
  content?: string;
  order?: number;
  taskId?: number;
}

export interface TitleDTO {
  id?: number;
  titleName?: string;
}

export interface TypeDTO {
  id?: number;
  typeName?: string;
}
