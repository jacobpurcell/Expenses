app.directive('addCategory', ['$resource', 'apiUrl', function ($resource, apiUrl) {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/add-category.html',
        controller: function ($scope) {
            $scope.addCategory = function () {
                $scope.categories.push($scope.newCategory);
            };
        }
    };
}]);