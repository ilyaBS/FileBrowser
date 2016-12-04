; (function (angular) {
    'use strict';

    angular.module('home', [])
        .controller('homeCtrl', ['$scope', 'ValuesService', '$resource',
            function ($scope, ValuesService, $resource) {
                                

                $scope.summary = {
                    Name: '',
                    Path: '',
                    Content:[],
                    FileCount10: 0,
                    FileCount50: 0,
                    FileCount100: 0
                }      

                $scope.updateFolder1 = function (newFolder) {
                    $scope.res = ValuesService.save({ 'path': newFolder.FullPath }, function (a, b)
                    {
                        $scope.summary = a;                        
                    });

                }
                $scope.res = $scope.updateFolder1({ FullPath: '' });

            }
        ])        
})(angular);