app.controller("ComputerDetailCtrl", ["$scope", "$http", "$location", "$routeParams", "ComputerService",
    function ($scope, $http, $location, $routeParams, ComputerService) {

        const getComputer = () => {
            ComputerService.getComputerById($routeParams.computerId).then((results) => {
                results.data.PurchaseDate = new Date(results.data.PurchaseDate);
                $scope.computer = results.data;
                console.log("computer:", results.data);
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
            ComputerService.deleteComputer(computerId).then(function (results) {
                $location.url(`/api/Computers`);
            }).catch(function (err) {
                    console.log("error in deleteComputer in controller");
                })
        };

    }
]);