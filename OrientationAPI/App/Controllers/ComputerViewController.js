app.controller("ComputerViewCtrl", ["$scope", "$http", "$location", "ComputerService",
    function ($scope, $http, $location, ComputerService) {

        $scope.formInputRequired = true;

        $http.get("/api/computers").then(function (result) {
            $scope.computers = result.data;
        });

        $scope.createComputerView = () => {
            $location.url(`/Computers/Create`);
        };

        $scope.newComputer = {};

        $scope.addComputerAndClose = function () {
            ComputerService.addComputer($scope.newComputer).then(function (results) {
                $location.url(`Computers`);
            }).catch(function (err) {
                console.log("error in addComputer in view controller");
            })
        }

        $scope.navigateToList = function () {
            $scope.formInputRequired = false;
            $location.url(`Computers`);
        };

        const computerDetailView = () => {
            $location.url(`/Computers/Detail/${computer.ComputerId}`);
        };

        $scope.computerDetail = {};

    }
]);

