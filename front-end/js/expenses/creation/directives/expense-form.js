﻿app.factory('commonFields', [function () {
    return [
        { name: "Project", type: 'String' },
        { name: "Date", type: 'Date' },
        { name: "Amount", type: "Decimal" },
        { name: "Currency", type: "String" },
        { name: "Rate", type: "Decimal" },
        { name: "Sterling", type: "Decimal" },
    ];
}]);

app.directive('expenseForm', [function () {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/creation/templates/expense-form.html',
        controller: function ($scope, commonFields) {
            $scope.fields = _(commonFields).map(function(field) {
                return {
                    name: field.name,
                    value: '',
                };
            });

            $scope.createExpense = function() {
                
            };
        }
    };
}]);