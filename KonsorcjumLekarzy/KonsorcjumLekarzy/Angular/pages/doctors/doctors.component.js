(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.doctors");

    controller.$inject = ["$http", "dataServices"];

    function controller($http, dataServices) {
        var vm = this;

        var parseInitData = function () {
            vm.initData.data = global_InitData.Doctors;
            for (var doctor = 0; doctor < vm.initData.data.length; doctor++) {
                vm.initData.doctorsList.push(vm.initData.data[doctor]);
                console.log("Add: " + vm.initData.data[doctor].FirstName);
            }
        };

        var getSelectedDoctor = function () {
            if (vm.initData.selectedDoctor === "" || vm.initData.selectedDoctor === undefined) {
                vm.initData.selectedDoctor = "No doctor has yet been selected";
            }
        };

        var getInitData = function() {
            $http.get('/home/GetInitialData')
                .success(function (data, status, header, config) {
                    console.log("Init data status: " + status);
                })
                .error(function(data, status, header, config) {
                    console.log("Init data error: " + status);
                });
        };

        vm.selectDoctors = function (item) {
            vm.initData.selectedDoctor.label = item.label;
            vm.initData.selectedDoctor.value = item.value;
        };

        vm.getActiveDoctor = function () {
            let active = {};
            active = vm.initData.doctorsList.filter(function (element, index, array) {
                return element.DoctorId === vm.initData.selectedDoctor.value;
            });
            return active;
        };
        
        vm.$onInit = function () {
            vm.initData = {};
            vm.initData.data = {}
            vm.initData.doctorsList = [];
            vm.initData.selectedDoctor = {};
            parseInitData();
            getInitData();
            getSelectedDoctor();
        }
    }

    module.component("doctors",
    {
        templateUrl: 'Angular/pages/doctors/doctors.html',
        controllerAs: "vm",
        controller: controller
    }); 

})();