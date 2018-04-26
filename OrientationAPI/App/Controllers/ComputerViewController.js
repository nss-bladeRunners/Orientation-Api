app.controller("ComputerViewCtrl", ["$scope", "$http",
    function ($scope, $http, $location) {

        $http.get("/api/computers").then(function (result) {
            $scope.computers = result.data;
        });

        $scope.createComputerView = () => {
            $location.url(`/Computers/Create`);
        };

        $scope.newComputer = {};

        $scope.createComputerAndClose = (newComputer) => {
            let c = $http.post("/api/computers/")
        }

    }
]);

