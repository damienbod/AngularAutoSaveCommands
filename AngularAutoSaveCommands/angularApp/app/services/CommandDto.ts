export class CommandDto {

    public CommandType: string;
    public PayloadType: string;
    public Payload: any;
    public ActualClientRoute: string;

    constructor(commandType: string, payloadType: string, payload: any, actualClientRoute: string) {

        this.CommandType = commandType;
        this.PayloadType = payloadType;
        this.Payload = payload;
        this.ActualClientRoute = actualClientRoute;

    }
}
