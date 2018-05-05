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

    const getUnassignedComputers = function () {
        return $q((resolve, reject) => {
            $http.get('http://localhost:50482/api/computers/unassigned'), JSON.stringify().then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in getUnassignedComputers in service", err);
            });
        });
    };

    const deleteComputer = function (computerId) {
        return $q((resolve, reject) => {
            $http.delete(`http://localhost:50482/api/computers/${computerId}`).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in deleteComputer in Service", err);
            });
        });
    };

    const assignComputer = function (employeeId, computerId) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/employees/${employeeId}/computer/${computerId}`).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in assignComputer in service", err);
            });
        });
    };

    return { addEmployee, updateEmployee, getUnassignedComputers, deleteComputer, assignComputer };

});