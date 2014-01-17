app.directive('newExpenseButton', function() {

    return {
        restrict: 'E',
        template: "<button ng-click='open()'>Add Expense</button>",
        controller: function($scope, $modal) {
            $scope.open = function() {
                $modal.open({
                    templateUrl: 'js/expenses/creation/templates/add-expense-dialog.html',

                    controller: function($scope, $modalInstance) {
                        $scope.ok = function() {
                            $modalInstance.close();
                        };

                        $scope.cancel = function() {
                            $modalInstance.dismiss('cancel');
                        };
                    },
                });
            };

        }
    };

});