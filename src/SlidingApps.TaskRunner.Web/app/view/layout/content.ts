/// <reference path="../../typings.d.ts" />

// COMMON
import { Component } from 'ng-forward';

@Component({
    selector: 'content',
    template: `
    <!-- CONTENT: BEGIN -->
    <data-ui-view></data-ui-view>
    <!-- CONTENT: END -->
    `
})
export class Content { }
