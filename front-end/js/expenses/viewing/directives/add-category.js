app.directive('addCategory', ['$resource', 'apiUrl', function ($resource, apiUrl) {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/add-category.html',
        controller: function ($scope) {
            $scope.addCategory = function () {
                var categoryResource = $resource(apiUrl + '/api/category');
                var newCategoryResource = new categoryResource();
                newCategoryResource.category = $scope.newCategory;
                newCategoryResource.$save({}, function success() { $scope.categories.push($scope.newCategory); }, function err() { /* we'd want some kind of flash here */ });
            };
        }
    };
}]);