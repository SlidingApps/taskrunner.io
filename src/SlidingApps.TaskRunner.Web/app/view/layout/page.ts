/// <reference path="../../typings.d.ts" />

// COMMON
import { Component } from 'ng-forward';

// COMPONENTS
import { Navigation } from '../../view/layout/navigation/navigation';
import { Content } from '../../view/layout/content/content';

@Component({
    selector: 'page',
    directives: [ Navigation, Content],
    template: `
    <!-- LAYOUT.PAGE: BEGIN -->
    <navigation></navigation>
    <content></content>
    <!-- LAYOUT.PAGE: END -->
    `
})
export class Page {}
