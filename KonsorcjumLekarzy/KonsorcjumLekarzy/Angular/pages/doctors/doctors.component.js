(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.doctors");

    controller.$inject = ['$http'];

    function controller($http) {
        var vm = this;
        var initData = {};

        var parseInitData = function () {
            for (var doctor = 0; doctor < initData.DoctorDto.length; doctor++) {
                vm.doctorsList.push(initData.DoctorDto[doctor]);
                console.log("Add: " + initData.DoctorDto[doctor]);
            }
        };

        var getInitData = function() {
            $http.get('/home/GetInitialData')
                .success(function (data, status, header, config) {
                    console.log("Init data status: " + status);
                    initData = data;
                    parseInitData();
                })
                .error(function(data, status, header, config) {
                    console.log("Init data error: " + status);
                });
        };

        vm.$onInit = function () {
            vm.doctorsList = [];
            getInitData();
        }
    }

    module.component("doctors",
    {
        templateUrl: 'Angular/pages/doctors/doctors.html',
        controllerAs: "vm",
        controller: controller
    }); 

})();