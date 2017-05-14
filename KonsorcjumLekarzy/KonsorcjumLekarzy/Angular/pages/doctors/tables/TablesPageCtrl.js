(function() {
    "use strict";

    const module = angular.module("BlurAdmin.pages.doctors");
    tablesPageCtrl.$inject = [];

    function tablesPageCtrl($filter) {
        var vm = this;

        var parseInitData = function() {
            if (vm.doctorsData !== null && vm.doctorsData !== undefined) {
                for (let i = 0; i < vm.doctorsData.length; i++) {
                    vm.smartTableData.push({
                        id: vm.doctorsData[i].DoctorId,
                        firstName: vm.doctorsData[i].FirstName,
                        lastName: vm.doctorsData[i].LastName,
                        username: vm.doctorsData[i].UserDto.UserName,
                        specialization: vm.doctorsData[i].SpecializationDto.SpecializationName,
                        age: vm.doctorsData[i].BirthDay
                    });
                }
            }
        };

        vm.getTableData = function() {
            parseInitData();
            vm.getTableDateButtonAvaliable = false;
        };

        vm.$onInit = function() {
            vm.getTableDateButtonAvaliable = true;
            vm.smartTableData = [];
            vm.smartTablePageSize = 10;
        };
    }

    module.component("tablesPage",
    {
        templateUrl: "Angular/pages/doctors/tables/templates/smartTable.html",
        controllerAs: "vm",
        controller: tablesPageCtrl,
        bindings: {
            doctorsData: "<"
        }
    });
})();