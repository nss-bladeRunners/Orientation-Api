app.service("DepartmentService", function ($http, $q, $rootScope) {

    const getAllDepartments = function () {
        var departmentList = [];
        return $q((resolve, reject) => {
            $http.get(`http://localhost:50482/api/departments`).then(function (results) {
                var departments = results.data;
                Object.keys(departments).forEach(function (key) {
                    departmentList.push(departments[key]);
                });
                console.log(departmentList);
                resolve(departmentList);
            }).catch(function (err) {
                reject("error in getAllDepartments in Service", err);
            });
        });
    };

    const getEmployeesByDepartmentId = function (departmentId) {
        return $http.get(`/api/departments/${departmentId}/employees`);
    };

    const getDepartmentById = function (departmentId) {
        return $http.get(`/api/departments/${departmentId}`)
    };

    const addDepartment = function (department) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/departments`, JSON.stringify(department)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addDepartment in Service", err);
            });
        });
    };
    return { getAllDepartments, addDepartment, getEmployeesByDepartmentId, getDepartmentById };
});