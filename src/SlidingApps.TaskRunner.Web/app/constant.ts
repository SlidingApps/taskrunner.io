/// <reference path="./typings.d.ts" />

export default 
    angular.module('application.constant', [])
        .constant('READMODEL_HOST', 'http://sazuattsuperman.cloudapp.net:81')
        // .constant('READMODEL_HOST', 'http://localhost:8081')
        .constant('READMODEL_API', 'query')
        ;
