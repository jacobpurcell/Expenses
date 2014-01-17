app.directive('deleteCategory', ['$resource', 'apiUrl', function ($resource, apiUrl) {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/delete-category.html',
        controller: function ($scope) {
            $scope.deleteCategory = function () {
                var categoryResource = $resource(apiUrl + '/api/category/:categoryName', { categoryName: $scope.category.Name });
                var newCategoryResource = new categoryResource();
                //newCategoryResource.categoryName = $scope.category.Name;
                
                newCategoryResource.$delete({}, function success() {
                    var index = $scope.categories.indexOf($scope.category);
                    if (index > -1) {
                        $scope.categories.splice(index, 1);
                    }
                }, function err() {
                    /* we'd want some kind of flash here */
                });
            };
        }
    };
}]);