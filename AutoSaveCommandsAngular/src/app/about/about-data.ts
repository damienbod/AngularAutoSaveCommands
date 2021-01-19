export class AboutData {

    public id = 0;
    public description = '';
    public deleted = false;

    constructor(id: number, description: string, deleted: boolean) {

        this.id = id;
        this.description = description;
        this.deleted = deleted;
    }
}
