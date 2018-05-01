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

     const getComputerById = (computerId) => {
         return $http.get(`/api/computers/${computerId}`);
     };

     const updateComputerDetails = (computer) => {
         return $q((resolve, reject) => {
             $http.put(`/api/computers/${computer.ComputerId}`, computer).then(function (results) {
                 resolve(results);
             }).catch(function (err) {
                 reject("error in updateComputerDetails in Service", err);
             });
         });
     }

     return { addComputer, getComputerById, updateComputerDetails };
});