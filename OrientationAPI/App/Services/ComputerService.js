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

     const deleteComputer = (computerId) => {
         return $q((resolve, reject) => {
             $http.delete(`/api/computers/${computerId}`).then(function (results) {
                 resolve(results);
             }).catch(function (err) {
                 reject("error in deleteComputer in Service", err);
             });
         });
     }

     const getEmployeeComputer = (computerId) => {
         return $q((resolve, reject) => {
             $http.get(`/api/employeeComputers/${computerId}`).then(function (results) {
                 resolve(results);
                 if (results) return true;
             }).catch(function (err) {
                 reject("error in getEmployeeComputer in service", err);
             });
         });
     }

     return { addComputer, deleteComputer, getComputerById, getEmployeeComputer, updateComputerDetails };
});