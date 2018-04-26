app.controller("EmployeesController", ["$scope", "$http",
    function ($scope, $http) {
        $scope.header = "Employees";

        $http.get("/api/employees").then(function (result) {
            $scope.employees = result.data;
        }).catch(function (err) {
            console.log(err);
        });
    }
]);