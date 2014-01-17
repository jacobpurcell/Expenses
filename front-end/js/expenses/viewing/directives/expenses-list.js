app.factory('apiUrl', function() {
    return "/ExpensesApi";
});

app.factory('visibleColumns', function () {
    return ["Name", "Project", "Date", "Amount", "Currency", "Rate", "Sterling"];
});

app.factory('expensesResource', ['$resource', 'apiUrl', function($resource, apiUrl) {
    return $resource(apiUrl + '/api/expenses/:id');
}]);

app.factory('expensesList', ['$resource', 'apiUrl', 'expensesResource', function ($resource, apiUrl, expensesResource) {
    var expenses = expensesResource.query(function () {
    }, true);

    return expenses;
}]);

app.directive('expensesList', function () {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/expenses-list.html',
        
        controller: function ($scope, expensesList, visibleColumns) {
            //var gridcolumnDefinitions = [];

            var columnDefinitions = _(visibleColumns).map(function(columnName) {
                return {
                    field: columnName,
                    displayName: columnName
                };
            });

            $scope.expenses = expensesList;

            $scope.gridOptions = {
                data: 'expenses',
                multiSelect: false,
                showColumnMenu: true,
                columnDefs: columnDefinitions
            };
        }
    };
});