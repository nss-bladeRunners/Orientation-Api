app.service("ModelTransferService", function ($http, $q, $rootScope) {
    var savedData = {}

    function setModel(data) {
        savedData = data;
    }
    function getModel() {
        return savedData;
    }

    return {setModel, getModel };
});