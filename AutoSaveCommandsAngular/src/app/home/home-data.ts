export class HomeData {

    public id = 0;
    public name = '';
    public deleted = false;

    constructor(id: number, name: string, deleted: boolean) {

        this.id = id;
        this.name = name;
        this.deleted = deleted;
    }
}
