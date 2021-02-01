import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo'
import { TodoApi } from '../../models/todoApi'
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})

export class TodoListComponent implements OnInit {

  title: string = 'Todo List';
  todoItems: Todo[] = [];
  inputTodo: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.todoItems = [
      {
        id: 1,
        isActive: true,
        note: 'Some note 1',
        isDone: false,
        order: 1
      },
      {
        id: 2,
        isActive: true,
        note: 'Some note 2',
        isDone: true,
        order: 2
      }
    ]
  }

  public deleteTodo(id: number) {
    this.todoItems = this.todoItems.filter((v, i) => v.id !== id);
  }

  public addTodo() {
    var length = this.todoItems.length + 1;
    var todo: Todo = {
      id: length,
      isActive: true,
      note: this.inputTodo,
      isDone: false,
      order: length
    };
    this.todoItems.push(todo);
  }

  /*public getTodoItems(): Observable<Todo[]>{
    return this.http.get(`${environment.apiUrl}/ToDoItems`)
    .pipe(
      map((todos: TodoApi[]): Todo[] => todos.map((todoData: TodoApi) => TodoListComponent.mapToUi(todoData))));
  }

  private static mapToUi(todoApi: TodoApi): Todo {
    return {
      id: todoApi.id,
      isActive: todoApi.isActive,
      note: todoApi.note,
      isDone: todoApi.isDone,
      order: todoApi.order
    };
  }*/

}
