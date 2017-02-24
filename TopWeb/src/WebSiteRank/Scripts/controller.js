(function () {
    'use strict';

    angular
        .module('WebSiteapp')
        .controller('WebSiteController', WebSiteController);

    WebSiteController.$inject = ['$scope', 'WebSite'];

    function WebSiteController($scope, WebSite) {
     
        $scope.WebSite = WebSite.APIData();
    }
})();
