app.controller("ComputerViewCtrl", ["$scope", "$http", "$location", "ComputerService",
    function ($scope, $http, $location, ComputerService) {

        $http.get("/api/computers").then(function (result) {
            $scope.computers = result.data;
        });

        $scope.createComputerView = () => {
            $location.url(`/Computers/Create`);
        };

        $scope.newComputer = {};

        $scope.addComputerAndClose = function () {
            ComputerService.addComputer($scope.newComputer).then(function (results) {
                console.log(results);
            }).catch(function (err) {
                console.log("error in addComputer in view controller");
            })
        }

    }
]);

