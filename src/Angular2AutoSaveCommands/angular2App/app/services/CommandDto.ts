export class CommandDto {
    constructor(commandType: string, payloadType: string, payload: any, actualClientRoute: string) {

        this.CommandType = commandType;
        this.PayloadType = payloadType;
        this.Payload = payload;
        this.ActualClientRoute = actualClientRoute;

    }

    CommandType: string;
    PayloadType: string;
    Payload: any;
    ActualClientRoute: string;
}
