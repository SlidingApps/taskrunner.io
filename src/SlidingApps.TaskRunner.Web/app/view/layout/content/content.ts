/// <reference path="../../../typings.d.ts" />

// COMMON
import { Component } from 'ng-forward';

@Component({
    selector: 'content',
    template: `
    <!-- LAYOUT.CONTENT: BEGIN -->
    <data-ui-view></data-ui-view>
    <!-- LAYOUT.CONTENT: END -->
    `
})
export class Content { }
