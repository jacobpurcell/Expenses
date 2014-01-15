app.directive('expensesList', function() {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/viewing/templates/expenses-list.html',
        controller: function($scope, $resource) {
            var expensesResource = $resource('/ExpensesApi/api/expenses');
            $scope.expenses = expensesResource.query(function() { }, true);
        }
    };
});