app.factory('commonFields', [function () {
    return [
        { name: "Project", type: 'String', required: true },
        { name: "Date", type: 'Date', required: true },
        { name: "Amount", type: "Decimal" },
        { name: "Currency", type: "String" },
        { name: "Rate", type: "Decimal" },
        { name: "Sterling", type: "Decimal" }
    ];
}]);

app.directive('expenseForm', [function () {
    return {
        restrict: 'E',
        templateUrl: 'js/expenses/creation/templates/expense-form.html',
        controller: function ($scope, commonFields, $resource, expensesResource) {
            $scope.fields = _(commonFields).map(function (field) {
                return {
                    name: field.name,
                    type: field.type,
                    value: '',
                    required: field.required
                };
            });

            $scope.createExpense = function (fields) {
                var expense = new expensesResource();

                _(fields).forEach(function (field) {
                    expense[field.name] = field.value;
                });
                
                expense.$save();
            };
        }
    };
}]);