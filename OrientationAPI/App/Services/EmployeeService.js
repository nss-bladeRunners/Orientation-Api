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

    const updateEmployee = function (employee) {
        return $q((resolve, reject) => {
            $http.put(`http://localhost:50482/api/employees/${employee.EmployeeId}`, JSON.stringify(employee)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in updateEmployee in Service", err);
            });
        });
    };


    //const updateComputer = function (computerId) {
    //    return $q((resolve, reject) => {
    //        $http.put(`http://localhost:50482/api/employees/${employeeId}/computer`), JSON.stringify()
    //    })
    //}

    return { addEmployee, updateEmployee };

});