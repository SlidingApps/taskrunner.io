
import { IEvent } from '../../component/foundation/event';

export interface IAuthenticationStateChangedEvent extends IEvent {
    isSignedIn: boolean;
    account?: { id: string, emailAddress: string, username: string };
}

export class AuthenticationStateChangedEvent implements IAuthenticationStateChangedEvent {
    constructor (public isSignedIn: boolean, public account?: { id: string, emailAddress: string, username: string }) { }
}
