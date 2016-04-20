/// <reference path="./typings.d.ts" />

const Module: angular.IModule =
    angular.module('application.constant', [])
        
        // .constant('WRITEMODEL_HOST', 'http://sazuattsuperman.cloudapp.net:81')
        .constant('WRITEMODEL_HOST', 'http://localhost:8081')
        .constant('WRITEMODEL_API', 'command')
            
        // .constant('READMODEL_HOST', 'http://sazuattsuperman.cloudapp.net:82')
        .constant('READMODEL_HOST', 'http://localhost:8082')
        .constant('READMODEL_API', 'query')
        ;

export { Module }
