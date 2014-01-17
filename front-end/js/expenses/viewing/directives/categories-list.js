app.factory('apiUrl', function () {  // TODO: shouldn't this go in expenses.js?
    return "/ExpensesApi";
});

app.factory('categoriesList', ['$q', '$resource', 'apiUrl', function ($q, $resource, apiUrl) {
    var categoriesResource = $resource(apiUrl + '/api/category');
    var categories = categoriesResource.query(function () {
    }, true);

    return categories;
}]);

app.directive('categoriesList', function () {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/categories-list.html',
        controller: function ($scope, categoriesList) {
            $scope.categories = categoriesList;
        }
    };
});