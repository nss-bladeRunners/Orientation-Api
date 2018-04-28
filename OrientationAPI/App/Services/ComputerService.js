app.service("ComputerService", function ($http, $q) {

     var addComputer = function (newComputer) {
        return $q((resolve, reject) => {
            $http.post(`/api/computers`, newComputer).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addComputer in Service", err);
            });
        });
    }
    return { addComputer };
});