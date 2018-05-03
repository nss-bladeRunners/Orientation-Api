app.service("EmployeeService", function ($http, $q, $rootScope) {

    const addEmployee = function (employee) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/employees/create`, JSON.stringify(employee)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addEmployee in Service", err);
            });
        });
    };

    const getAvailableTrainings = function (employeeId) {
        return $q((resolve, reject) => {
            $http.get(`http://localhost:50482/api/employees/${employeeId}/availableTrainings`).then(function (results) {
                resolve(results.data);
            }).catch(function (err) {
                reject("error in getAvailableTrainings in Service", err);
            });
        });
    };

    return { addEmployee, getAvailableTrainings };

});