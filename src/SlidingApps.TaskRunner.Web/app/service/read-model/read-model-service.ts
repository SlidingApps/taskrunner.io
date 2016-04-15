/// <reference path="../../typings.d.ts" />

// COMMON
import { Injectable, Inject } from 'ng-forward';
import { RestService } from '../rest/rest-service';

// MODEL
import { ITenantCodeAvailability } from './representation/tenant-code-availability';


@Injectable()
@Inject('$q', RestService, 'READMODEL_HOST', 'READMODEL_API')
export class ReadModelService {

    constructor(private $q: ng.IQService, private service: RestService, private hostUrl: any, private apiPath: any) {
        this.service.defaultConfiguration.host.url = hostUrl;
        this.service.defaultConfiguration.api.path = apiPath;
    }

    private static TENANT_RESOURCE: string = 'tenants';

    public getTenantCodeAvailability(code: string): ng.IPromise<ITenantCodeAvailability> {
        return this.service.all(`${ReadModelService.TENANT_RESOURCE}/${code}/availability`).get();
    }

}
