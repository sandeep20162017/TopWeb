(function () {
    'use strict';

    var WebSiteService = angular.module('WebSiteService', ['ngResource']);
    WebSiteService.factory('WebSite', ['$resource',
        function ($resource) {
            
            return $resource('/api/WebSiteMasters/', {}, {

                APIData: { method: 'GET', params: {}, isArray: true }

            });
            
        }
    ]);
})();