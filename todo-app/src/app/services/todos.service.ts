import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Todo } from '../models/todo';
import { TodoApi } from '../models/todoApi';

@Injectable()
export class TodosService {
  constructor(private http: HttpClient) {}

  public getAll() {
    return this.http.get<Todo[]>(`${environment.apiUrl}/ToDoItems`);
  }

  public update(todo: Todo) {
    return this.http.put<Todo>(
      `${environment.apiUrl}/ToDoItems`,
      TodosService.toApi(todo)
    );
  }

  public create(todo: Todo) {
    return this.http.post<Todo>(
      `${environment.apiUrl}/ToDoItems`,
      TodosService.toApi(todo)
    );
  }

  public delete(id: number) {
    return this.http.delete<TodoApi>(`${environment.apiUrl}/ToDoItems/${id}`);
  }

  private static toApi(todo: Todo): TodoApi {
    return {
      id: todo.id,
      isActive: todo.isActive,
      note: todo.note,
      isDone: todo.isDone,
      order: todo.order,
    };
  }
}
