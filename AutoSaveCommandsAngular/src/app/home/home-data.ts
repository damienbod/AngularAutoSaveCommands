export class HomeData {

    public Id = 0;
    public Name = '';
    public Deleted = false;

    constructor(id: number, name: string, deleted: boolean) {

        this.Id = id;
        this.Name = name;
        this.Deleted = deleted;
    }
}
