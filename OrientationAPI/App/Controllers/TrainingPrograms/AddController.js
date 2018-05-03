app.controller("TrainingPrograms/AddController", ["$scope", "$http", "$location", "TrainingProgramService", "ModelTransferService",
    function ($scope, $http, $location, TrainingProgramService, ModelTransferService) {

        const addTraining = function () {
            TrainingProgramService.addTraining($scope.program).then(function () {
                $scope.navigateToList(); 
            }).catch(function (err) {
                console.log("error in addtraining in controller", err);
            })
        }

        $scope.navigateToList = function () {
            $location.path(`/Training`);
        }

        $scope.submitNewProgram = function () {
            addTraining();
        }

        //must declare program object in order to receive it from the child scope FormController
        $scope.program = {}

    }
]);
