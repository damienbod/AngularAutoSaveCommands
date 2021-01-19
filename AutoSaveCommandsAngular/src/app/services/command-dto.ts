export class CommandDto {

    public commandType: string;
    public payloadType: string;
    public payload: any;
    public actualClientRoute: string;

    constructor(commandType: string, payloadType: string, payload: any, actualClientRoute: string) {

        this.commandType = commandType;
        this.payloadType = payloadType;
        this.payload = payload;
        this.actualClientRoute = actualClientRoute;

    }
}
