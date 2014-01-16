app.factory('apiUrl', function() {
    return "/ExpensesApi";
});

app.factory('visibleColumns', function() {
    return ["ClaimNumber", "ReceiptNumber", "Customer", "Date", "Country", "Amount", "Currency", "Rate", "SterlingValue"];
    //return ["ClaimNumber"];
});

app.factory('expensesList', ['$q', '$resource', 'apiUrl', function ($q, $resource, apiUrl) {
    var expensesResource = $resource(apiUrl + '/api/expenses/:id');
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