export class TodoApi {
    id: number;
    isActive: boolean;
    note: string;
    isDone: boolean;
    order: number;

    constructor(id: number, isActive: boolean, note: string, isDone: boolean, order: number) {
        this.id = id;
        this.isActive = isActive;
        this.note = note;
        this.isDone = isDone;
        this.order = order;
    }
}