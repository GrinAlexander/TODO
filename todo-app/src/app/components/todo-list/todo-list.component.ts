import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo';
import { TodosService } from 'src/app/services/todos.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
  providers: [TodosService],
})
export class TodoListComponent implements OnInit {
  title: string = 'Todo List';
  todoItems: Todo[] = [];
  inputTodo: string = '';
  checked: boolean = false;

  constructor(private todosService: TodosService) {}

  ngOnInit(): void {
    this.getTodoItems();
  }

  public deleteTodo(id: number) {
    this.todosService.delete(id).subscribe((data) => {
      console.log(data);
      this.todoItems = this.todoItems.filter((x) => x.id != data.id);
    });
  }

  public addTodo() {
    var todo: Todo = {
      id: 0,
      isActive: true,
      note: this.inputTodo,
      isDone: false,
      order: length,
    };

    this.todosService.create(todo).subscribe((data) => {
      console.log(data);
      this.todoItems.push(data);
    });
  }

  public getTodoItems() {
    return this.todosService.getAll().subscribe((data) => {
      console.log(data);
      this.todoItems = data;
    });
  }

  // id is 0 in todo obj
  public changeIsDone(todo: Todo) {
    console.log(this.todoItems);

    todo.isDone = !todo.isDone;
    return this.todosService.update(todo).subscribe((data) => {
      console.log(data);
    });
  }
}
