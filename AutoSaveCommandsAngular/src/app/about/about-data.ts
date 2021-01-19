export class AboutData {

    public Id = 0;
    public Description = '';
    public Deleted = false;

    constructor(id: number, description: string, deleted: boolean) {

        this.Id = id;
        this.Description = description;
        this.Deleted = deleted;
    }
}
