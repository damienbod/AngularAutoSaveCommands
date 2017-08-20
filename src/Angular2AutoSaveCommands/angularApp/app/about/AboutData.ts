export class AboutData {

    public Id: number;
    public Description: string;
    public Deleted: boolean;

    constructor(id: number, description: string, deleted: boolean) {

        this.Id = id;
        this.Description = description;
        this.Deleted = deleted;
    }
}