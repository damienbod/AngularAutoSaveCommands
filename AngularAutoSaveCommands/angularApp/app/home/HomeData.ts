export class HomeData {

    public Id: number;
    public Name: string;
    public Deleted: boolean;

    constructor(id: number, name: string, deleted: boolean) {

        this.Id = id;
        this.Name = name;
        this.Deleted = deleted;
    }
}
