app.service("TrainingProgramService", function($http, $q, $rootScope) {

    const getAllUpcomingPrograms = function() {
        var programsList = [];
        return $q((resolve, reject) => {
            $http.get(`http://localhost:50482/api/training`).then(function (results) {
                var programs = results.data;
                Object.keys(programs).forEach(function (key) {
                    programsList.push(programs[key]);
                    });
                console.log(programsList);
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
    return { getAllUpcomingPrograms, addTraining };
});