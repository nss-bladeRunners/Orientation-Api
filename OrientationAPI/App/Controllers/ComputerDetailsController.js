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

        $scope.printStuff = (computer) => {
            ComputerService.getComputerById(computer.computerId).then(function (results) {
            }).catch(function (err) {
                console.log("error in updateComputer in controller", err);
            })
        };

        $scope.deleteComputer = function (computerId) {
            ComputerService.deleteComputer(computerId).then(function (results) {
                $location.url(`Computers`);
            }).catch(function (err) {
                console.log("error in deleteComputer in Controller", err);
            });
        };

        $scope.navigateToList = function () {
            $scope.formInputRequired = false;
            $location.url(`/Computers/Detail/${computer.ComputerId}`);
        };

        $scope.navigateToDetail = function () {
            $scope.formInputRequired = false;
            $location.url(`Computers`);
        };

    }
]);