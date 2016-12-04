(function (angular) {
    'use strict';

    var appRoutes = angular.module('app.routes', ['ngRoute']);
    // Collect the routes
    appRoutes.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    appRoutes.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });

        //$locationProvider.html5Mode(true);
    }

    // Define the routes 
    function getRoutes() {
        return [
			{
			    url: '/',
			    config: {
			        controller: 'homeCtrl'
			    }
			}
        ];
    }
})(angular);