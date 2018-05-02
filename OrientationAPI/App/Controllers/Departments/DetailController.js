app.controller("DetailController", ["$scope", "$http", "$location", "$routeParams", "DepartmentService",
    function ($scope, $http, $location, $routeParams, DepartmentService) {

    const getEmployeesByDepartmentId = function () {
        DepartmentService.getEmployeesByDepartmentId($routeParams.departmentId).then(function (results) {
            $scope.employee = results.data;
            console.log(results);
        }).catch(function (err) {
            console.log("error in getEmployeesByDepartmentById in controller", err);
         });
        }();

    const getDepartmentById = function () {
        DepartmentService.getDepartmentById($routeParams.departmentId).then(function (results) {
            $scope.department = results.data;
            console.log(results);
        }).catch(function (err) {
            console.log("error in getDepartmentById in controller", err);
        });
    }();


   }
]);

