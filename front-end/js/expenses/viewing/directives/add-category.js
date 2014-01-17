app.directive('addCategory', ['$resource', 'apiUrl', function ($resource, apiUrl) {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/add-category.html',
        controller: function ($scope) {
            $scope.addDetail = function () {
                if (!$scope.newCategory.Details)
                    $scope.newCategory.Details = [];
                $scope.newCategory.Details.push($scope.newDetail);
                $scope.newDetail = null;
            };
            $scope.saveCategory = function () {
                var categoryResource = $resource(apiUrl + '/api/category');
                var newCategoryResource = new categoryResource();
                newCategoryResource.category = $scope.newCategory;
                newCategoryResource.$save({}, function success() {
                    $scope.categories.push($scope.newCategory);
                    //$scope.newCategory = null;
                }, function err() {
                     /* we'd want some kind of flash here */
                });
            };
        }
    };
}]);