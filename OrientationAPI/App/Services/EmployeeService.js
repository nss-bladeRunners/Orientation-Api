﻿app.service("EmployeeService", function ($http, $q, $rootScope) {

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

    var addEmployeeTraining = function (employeeId, trainingId) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/employees/${employeeId}/addTraining/${trainingId}`).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addEmployeeTraining in Service", err);
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

    return { addEmployee, getAvailableTrainings, addEmployeeTraining };

});