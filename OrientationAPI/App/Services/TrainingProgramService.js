app.service("TrainingProgramService", function($http, $q, $rootScope) {

    const getAllUpcomingPrograms = function() {
        var programsList = [];
        return $q((resolve, reject) => {
            $http.get(`http://localhost:50482/api/training`).then(function (results) {
                var programs = results.data;
                Object.keys(programs).forEach(function (key) {
                    programsList.push(programs[key]);
                    });
                resolve(programsList);
            }).catch(function (err) {
                reject("error in getAllUpcomingProgram in Service", err);
            });
        });
    };

    const addTraining = function (program) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/training`, JSON.stringify(program)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addTraining in Service", err);
            });
        });
    }

    var getTrainingById = function (programId) {
        return $q((resolve, reject) => {
            $http.get(`http://localhost:50482/api/training/${programId}`).then(function (results) {
                resolve(results.data[0]);
            }).catch(function (err) {
                reject("error in getTrainingById in Service", err);
            });
        });
    }


    var updateTraining = function (program) {
        return $q((resolve, reject) => {
            $http.put(`http://localhost:50482/api/training`, JSON.stringify(program)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in getTrainingById in Service", err);
            });
        });
    }

    var deleteTraining = function (programId) {
        return $q((resolve, reject) => {
            $http.delete(`http://localhost:50482/api/training/${programId}`).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in deleteTraining in Service", err);
            });
        });
    }



    return { getAllUpcomingPrograms, addTraining, getTrainingById, updateTraining, deleteTraining };
});