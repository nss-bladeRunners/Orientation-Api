app.controller("ComputerViewCtrl", ["$scope", "$http",
    function ($scope, $http) {

        $http.get("/api/computers").then(function (result) {
            console.log("Get");
            $scope.computers = result.data;
        });
    }
]);

