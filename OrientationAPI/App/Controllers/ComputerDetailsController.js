app.controller("ComputerDetailCtrl", ["$scope", "$http", "$location", "$routeParams", "ComputerService",
    function ($scope, $http, $location, $routeParams, ComputerService) {

        const getComputer = () => {
            ComputerService.getComputerById($routeParams.computerId).then((results) => {
                results.data.PurchaseDate = new Date(results.data.PurchaseDate);
                $scope.computer = results.data;
            });
        };

        getComputer();

        $scope.updateComputer = (computer) => {
            ComputerService.updateComputerDetails(computer).then(function (results) {
                $location.url(`Computers`);
            }).catch(function (err) {
                    console.log("error in updateComputer in controller", err);
                })
        };

        $scope.deleteComputer = (computerId) => {
            $scope.alert = true;
            ComputerService.deleteComputer(computerId).then(function (results) {
                $location.url(`Computers`);
            }).catch(function (err) {
                    console.log("error in deleteComputer in controller");
                })
        };

        $scope.navigateToList = function () {
            $scope.formInputRequired = false;
            $location.url(`Computers`);
        };

    }
]);