app.controller("DepartmentController", ["$scope", "$http", "$location", "DepartmentService",
    function ($scope, $http, $location, DepartmentService) {

        //get upcoming project
        var getDepartments = function () {
            DepartmentService.getAllDepartments().then(function (results) {
                $scope.departments = results;
            }).catch(function (error) {
                console.log("error in getDepartments", error);
            });
        }();

        const addDepartment = function () {
            DepartmentService.addDepartment($scope.department).then(function (results) {
                console.log(results);
            }).catch(function (err) {
                console.log("error in addDepartment in controller", err);
            });
        };

        $scope.navigateToAdd = function () {
            var currentLocation = $location.path();
            $location.path(`/DepartmentsAdd`);
        };

        $scope.navigateToDepartmentList = function () {
            $location.path(`/Departments`);
        };

        $scope.submitNewDepartment = function () {
            addDepartment($scope.department);
            $location.path(`/Departments`);
        };
    }
]);